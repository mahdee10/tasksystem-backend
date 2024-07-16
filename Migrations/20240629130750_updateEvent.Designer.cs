﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskSystemServer.Data;

#nullable disable

namespace TaskSystemServer.Migrations
{
    [DbContext(typeof(TasksystemContext))]
    [Migration("20240629130750_updateEvent")]
    partial class updateEvent
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "190091ed-5328-4e17-81ac-e5a81332f8d2",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2db4138b-9ab0-4166-87b2-89e0a40fcfb8",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TaskSystemServer.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("TaskSystemServer.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("eventId");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("EventId"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<bool?>("IsReminded")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("memberId");

                    b.Property<int?>("RemindBeforeHours")
                        .HasColumnType("int")
                        .HasColumnName("remindBeforeHours");

                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("title");

                    b.HasKey("EventId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "MemberId" }, "memberId");

                    b.ToTable("event", (string)null);
                });

            modelBuilder.Entity("TaskSystemServer.Models.Globalevent", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("eventId");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("EventId"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("title");

                    b.HasKey("EventId")
                        .HasName("PRIMARY");

                    b.ToTable("globalevent", (string)null);
                });

            modelBuilder.Entity("TaskSystemServer.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("memberId");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<string>("AppUserId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateOnly?>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("dob");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("isActive")
                        .HasDefaultValueSql("'1'");

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("name");

                    b.Property<string>("Timezone")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("timezone");

                    b.HasKey("MemberId")
                        .HasName("PRIMARY");

                    b.HasIndex("AppUserId");

                    b.ToTable("member", (string)null);
                });

            modelBuilder.Entity("TaskSystemServer.Models.Memberprefernce", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("memberId");

                    b.Property<string>("Layout")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("layout")
                        .HasDefaultValueSql("'default'");

                    b.Property<string>("Theme")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(24)
                        .HasColumnType("varchar(24)")
                        .HasColumnName("theme")
                        .HasDefaultValueSql("'default'");

                    b.HasKey("MemberId")
                        .HasName("PRIMARY");

                    b.ToTable("memberprefernces", (string)null);
                });

            modelBuilder.Entity("TaskSystemServer.Models.Memberprofile", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("memberId");

                    b.Property<string>("ProfileUrl")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("profileUrl");

                    b.HasKey("MemberId")
                        .HasName("PRIMARY");

                    b.ToTable("memberprofile", (string)null);
                });

            modelBuilder.Entity("TaskSystemServer.Models.Registeredglobalevent", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("memberId");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("eventId");

                    b.Property<int?>("RemindBeforeHours")
                        .HasColumnType("int")
                        .HasColumnName("remindBeforeHours");

                    b.HasKey("MemberId", "EventId")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "EventId" }, "eventId");

                    b.ToTable("registeredglobalevent", (string)null);
                });

            modelBuilder.Entity("TaskSystemServer.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("taskId");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime")
                        .HasColumnName("dueDate");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("time")
                        .HasColumnName("duration");

                    b.Property<bool?>("IsDone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("isDone")
                        .HasDefaultValueSql("'0'");

                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("memberId");

                    b.Property<string>("PriorityLevel")
                        .HasColumnType("enum('high','low','medium')")
                        .HasColumnName("priorityLevel");

                    b.Property<int?>("RemindBeforeHours")
                        .HasColumnType("int")
                        .HasColumnName("remindBeforeHours");

                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("title");

                    b.HasKey("TaskId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "MemberId" }, "memberId")
                        .HasDatabaseName("memberId1");

                    b.ToTable("task", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TaskSystemServer.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TaskSystemServer.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskSystemServer.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TaskSystemServer.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskSystemServer.Models.Event", b =>
                {
                    b.HasOne("TaskSystemServer.Models.Member", "Member")
                        .WithMany("Events")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("event_ibfk_1");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("TaskSystemServer.Models.Member", b =>
                {
                    b.HasOne("TaskSystemServer.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("TaskSystemServer.Models.Memberprefernce", b =>
                {
                    b.HasOne("TaskSystemServer.Models.Member", "Member")
                        .WithOne("Memberprefernce")
                        .HasForeignKey("TaskSystemServer.Models.Memberprefernce", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("memberprefernces_ibfk_1");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("TaskSystemServer.Models.Memberprofile", b =>
                {
                    b.HasOne("TaskSystemServer.Models.Member", "Member")
                        .WithOne("Memberprofile")
                        .HasForeignKey("TaskSystemServer.Models.Memberprofile", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("memberprofile_ibfk_1");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("TaskSystemServer.Models.Registeredglobalevent", b =>
                {
                    b.HasOne("TaskSystemServer.Models.Globalevent", "Event")
                        .WithMany("Registeredglobalevents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("registeredglobalevent_ibfk_2");

                    b.HasOne("TaskSystemServer.Models.Member", "Member")
                        .WithMany("Registeredglobalevents")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("registeredglobalevent_ibfk_1");

                    b.Navigation("Event");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("TaskSystemServer.Models.Task", b =>
                {
                    b.HasOne("TaskSystemServer.Models.Member", "Member")
                        .WithMany("Tasks")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("task_ibfk_1");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("TaskSystemServer.Models.Globalevent", b =>
                {
                    b.Navigation("Registeredglobalevents");
                });

            modelBuilder.Entity("TaskSystemServer.Models.Member", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Memberprefernce");

                    b.Navigation("Memberprofile");

                    b.Navigation("Registeredglobalevents");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
