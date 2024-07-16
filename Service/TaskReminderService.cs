using Microsoft.EntityFrameworkCore;
using TaskSystemServer.Data;
using TaskSystemServer.Settings;

namespace TaskSystemServer.Service
{
    public class TaskReminderService: BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IEmailService _emailService;
        //private readonly TasksystemContext _context;

        public TaskReminderService(IServiceScopeFactory scopeFactory, IEmailService emailService)
        {
            _scopeFactory = scopeFactory;
            _emailService = emailService;
            //_context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetRequiredService<TasksystemContext>();

                    var now = DateTime.Now;
                    // Fetch events from database first
                    var tasks = await _context.Tasks.Include(task => task.Member).ToListAsync(stoppingToken);

                    // Perform in-memory filtering
                    var upcomingTasks = tasks.Where(e => e.Date.HasValue &&
                                                            e.RemindBeforeHours.HasValue &&
                                                            e.DueDate.Value.Subtract(TimeSpan.FromHours(e.RemindBeforeHours.Value)) <= now)
                                               .ToList();
                    foreach (var task in upcomingTasks)
                    {
                        var user = _context.Users.Find(task.Member.AppUserId);
                        if (user != null)
                        {
                            var subject = $"Reminder for Task: {task.Title}";
                            var message = $"This is a reminder for your upcoming task: {task.Title} at {task.DueDate}. Description: {task.Description}";

                            await _emailService.SendEmailAsync(user.Email, subject, message);
                        }
                        task.RemindBeforeHours = null;
                    }
                    await _context.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }



        }
    }
}
