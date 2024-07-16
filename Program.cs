using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TaskSystemServer.Data;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Models;
using TaskSystemServer.Repository;
using TaskSystemServer.Service;
using TaskSystemServer.Settings;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<TasksystemContext>(
    options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
    );

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 12;
}).AddEntityFrameworkStores<TasksystemContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ClockSkew = TimeSpan.Zero,
        ValidateLifetime = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
            )
    };
});

//builder.Services.Configure<SmtpSettings>(options =>
//{
//    options.Server = Environment.GetEnvironmentVariable("SMTP_SERVER");
//    options.Port = int.Parse(Environment.GetEnvironmentVariable("SMTP_PORT"));
//    options.SenderName = Environment.GetEnvironmentVariable("SMTP_SENDER_NAME");
//    options.SenderEmail = Environment.GetEnvironmentVariable("SMTP_SENDER_EMAIL");
//    options.Username = Environment.GetEnvironmentVariable("SMTP_USERNAME");
//    options.Password = Environment.GetEnvironmentVariable("SMTP_PASSWORD");
//});

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

// Register EmailService and EventReminderService
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddHostedService<EventReminderService>();
builder.Services.AddHostedService<TaskReminderService>();
builder.Services.AddHostedService<GlobalEventReminderService>();

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IPrefernceRepository, PreferenceRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IGlobalEventRepository, GlobalEventRepository>();
builder.Services.AddScoped<IRegisteredglobaleventRepository, RegisteredglobaleventRepository>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
