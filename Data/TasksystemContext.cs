using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using TaskSystemServer.Models;

namespace TaskSystemServer.Data;

public partial class TasksystemContext : IdentityDbContext<AppUser>
{


    public TasksystemContext()
    {
    }

    public TasksystemContext(DbContextOptions<TasksystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Globalevent> Globalevents { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Memberprefernce> Memberprefernces { get; set; }

    public virtual DbSet<Memberprofile> Memberprofiles { get; set; }

    public virtual DbSet<Registeredglobalevent> Registeredglobalevents { get; set; }

    public virtual DbSet<TaskSystemServer.Models.Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=tasksystem;user=root;password=1968", ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
        modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
        modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();

        base.OnModelCreating(modelBuilder);

        List<IdentityRole> roles = new List<IdentityRole>() {
            new IdentityRole
            {
                Name="Admin",
                NormalizedName="ADMIN"
            },
            new IdentityRole
            {
                Name="User",
                NormalizedName="USER"
            }
        };

        modelBuilder.Entity<IdentityRole>().HasData(roles);

        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PRIMARY");

            entity.ToTable("event");

            entity.HasIndex(e => e.MemberId, "memberId");

            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.RemindBeforeHours).HasColumnName("remindBeforeHours");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");

            entity.HasOne(d => d.Member).WithMany(p => p.Events)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("event_ibfk_1");
        });

        modelBuilder.Entity<Globalevent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PRIMARY");

            entity.ToTable("globalevent");

            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PRIMARY");

            entity.ToTable("member");

            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("'1'")
                .HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
            entity.Property(e => e.Timezone)
                .HasMaxLength(50)
                .HasColumnName("timezone");
        });

        modelBuilder.Entity<Memberprefernce>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PRIMARY");

            entity.ToTable("memberprefernces");

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever()
                .HasColumnName("memberId");
            entity.Property(e => e.Layout)
                .HasMaxLength(25)
                .HasDefaultValueSql("'default'")
                .HasColumnName("layout");
            entity.Property(e => e.Theme)
                .HasMaxLength(24)
                .HasDefaultValueSql("'default'")
                .HasColumnName("theme");

            entity.HasOne(d => d.Member).WithOne(p => p.Memberprefernce)
                .HasForeignKey<Memberprefernce>(d => d.MemberId)
                .HasConstraintName("memberprefernces_ibfk_1");
        });

        modelBuilder.Entity<Memberprofile>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PRIMARY");

            entity.ToTable("memberprofile");

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever()
                .HasColumnName("memberId");
            entity.Property(e => e.ProfileUrl)
                .HasMaxLength(255)
                .HasColumnName("profileUrl");

            entity.HasOne(d => d.Member).WithOne(p => p.Memberprofile)
                .HasForeignKey<Memberprofile>(d => d.MemberId)
                .HasConstraintName("memberprofile_ibfk_1");
        });

        modelBuilder.Entity<Registeredglobalevent>(entity =>
        {
            entity.HasKey(e => new { e.MemberId, e.EventId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("registeredglobalevent");

            entity.HasIndex(e => e.EventId, "eventId");

            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.RemindBeforeHours).HasColumnName("remindBeforeHours");

            entity.HasOne(d => d.Event).WithMany(p => p.Registeredglobalevents)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("registeredglobalevent_ibfk_2");

            entity.HasOne(d => d.Member).WithMany(p => p.Registeredglobalevents)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("registeredglobalevent_ibfk_1");
        });

        modelBuilder.Entity<TaskSystemServer.Models.Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PRIMARY");

            entity.ToTable("task");

            entity.HasIndex(e => e.MemberId, "memberId");

            entity.Property(e => e.TaskId).HasColumnName("taskId");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("dueDate");
            entity.Property(e => e.Duration)
                .HasColumnType("time")
                .HasColumnName("duration");
            entity.Property(e => e.IsDone)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isDone");
            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.PriorityLevel)
                .HasColumnType("enum('high','low','medium')")
                .HasColumnName("priorityLevel");
            entity.Property(e => e.RemindBeforeHours).HasColumnName("remindBeforeHours");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");

            entity.HasOne(d => d.Member).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("task_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
