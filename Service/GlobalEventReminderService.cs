using Microsoft.EntityFrameworkCore;
using TaskSystemServer.Data;
using TaskSystemServer.Settings;
namespace TaskSystemServer.Service
{
    public class GlobalEventReminderService: BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IEmailService _emailService;
        //private readonly TasksystemContext _context;

        public GlobalEventReminderService(IServiceScopeFactory scopeFactory, IEmailService emailService)
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
                    var events = await _context.Registeredglobalevents.Include(e => e.Member ).Include(e => e.Event).ToListAsync(stoppingToken);

                    // Perform in-memory filtering
                    var upcomingEvents = events.Where(e => e.Event.Date.HasValue &&
                                                            e.RemindBeforeHours.HasValue &&
                                                            e.Event.Date.Value.Subtract(TimeSpan.FromHours(e.RemindBeforeHours.Value)) <= now
                                                            && e.IsReminded == false)
                                               .ToList();
                    foreach (var ev in upcomingEvents)
                    {

                        var user = _context.Users.Find(ev.Member.AppUserId);
                        if (user != null)
                        {
                            var subject = $"Reminder for Global Event: {ev.Event.Title}";
                            var message = $"This is a reminder for an upcoming global event: {ev.Event.Title} at {ev.Event.Date}. Description: {ev.Event.Description}";

                            await _emailService.SendEmailAsync(user.Email, subject, message);
                        }
                        ev.IsReminded = true;
                    }
                    await _context.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }



        }

    }
}