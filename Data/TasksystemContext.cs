using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskSystemServer.Models;

namespace TaskSystemServer.Data
{
    public partial class TasksystemContext : IdentityDbContext<AppUser>
    {
        public TasksystemContext() { }

        public TasksystemContext(DbContextOptions<TasksystemContext> options)
            : base(options)
        { }

        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Memberprefernce> Memberprefernces { get; set; }
        public virtual DbSet<Memberprofile> Memberprofiles { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<TaskSystemServer.Models.Task> Tasks { get; set; }
        public virtual DbSet<Globalevent> Globalevents { get; set; }
        public virtual DbSet<Registeredglobalevent> Registeredglobalevents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use Npgsql for PostgreSQL
            optionsBuilder.UseNpgsql("Host=dpg-d0b67m3e5dus7380jfl0-a.oregon-postgres.render.com;Database=tasksystem;Username=tasksystem_user;Password=cueXmQUKkwsOGFyWuFdfbhyFtSnAOkTv;Port=5432");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Member-Preference Relationship
            modelBuilder.Entity<Memberprefernce>(entity =>
            {
                entity.HasKey(e => e.MemberId);  // MemberId as primary key
                entity.Property(e => e.MemberId).HasColumnName("memberId");
                entity.Property(e => e.Layout).HasColumnName("layout").HasDefaultValue("default");
                entity.Property(e => e.Theme).HasColumnName("theme").HasDefaultValue("default");

                entity.HasOne(d => d.Member)
                    .WithOne(p => p.Memberprefernce)
                    .HasForeignKey<Memberprefernce>(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Member-Profile Relationship
            modelBuilder.Entity<Memberprofile>(entity =>
            {
                entity.HasKey(e => e.MemberId);
                entity.Property(e => e.MemberId).HasColumnName("memberId");
                entity.Property(e => e.ProfileUrl).HasColumnName("profileUrl");

                entity.HasOne(d => d.Member)
                    .WithOne(p => p.Memberprofile)
                    .HasForeignKey<Memberprofile>(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Event-RegisteredGlobalEvent Relationship
            modelBuilder.Entity<Registeredglobalevent>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.EventId });

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Registeredglobalevents)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Registeredglobalevents)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Task-Member Relationship
            modelBuilder.Entity<TaskSystemServer.Models.Task>(entity =>
            {
                entity.HasKey(e => e.TaskId);
                entity.Property(e => e.TaskId).HasColumnName("taskId");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.DueDate)
      .HasColumnType("timestamp with time zone")
      .HasColumnName("dueDate");

                entity.Property(e => e.Date)
                      .HasColumnType("timestamp with time zone")
                      .HasColumnName("date");

                entity.Property(e => e.RemindBeforeHours).HasColumnName("remindBeforeHours");
                entity.Property(e => e.PriorityLevel).HasColumnName("priorityLevel");
                entity.Property(e => e.IsDone).HasColumnName("isDone").HasDefaultValue(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Event-Event Relationship (GlobalEvent)
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EventId);
                entity.Property(e => e.EventId).HasColumnName("eventId");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Date).HasColumnType("timestamp").HasColumnName("date");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // GlobalEvent configuration
            modelBuilder.Entity<Globalevent>(entity =>
            {
                entity.HasKey(e => e.EventId);
                entity.Property(e => e.EventId).HasColumnName("eventId");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Date).HasColumnType("timestamp").HasColumnName("date");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}