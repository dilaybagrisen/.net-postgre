﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SporEtkinlikleriYonetimSistemi.Data;

#nullable disable

namespace SporEtkinlikleriYonetimSistemi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SporEtkinlikleriYonetimSistemi.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EventID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrganizerID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("EventID");

                    b.HasIndex("OrganizerID");

                    b.ToTable("Events", t =>
                        {
                            t.HasCheckConstraint("chk_event_dates", "\"StartDate\" < \"EndDate\"");
                        });
                });

            modelBuilder.Entity("SporEtkinlikleriYonetimSistemi.Models.EventParticipant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("EventID")
                        .HasColumnType("integer");

                    b.Property<int>("ParticipantID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("EventID");

                    b.HasIndex("ParticipantID");

                    b.ToTable("EventParticipants");
                });

            modelBuilder.Entity("SporEtkinlikleriYonetimSistemi.Models.EventSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventSchedules");
                });

            modelBuilder.Entity("SporEtkinlikleriYonetimSistemi.Models.Participant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("EventID")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("EventID");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("SporEtkinlikleriYonetimSistemi.Models.ParticipantWithEventViewModel", b =>
                {
                    b.Property<DateTime?>("eventenddate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("eventid")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("eventstartdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("eventtitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("id")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("ParticipantWithEventViewModels");

                    b.ToFunction("getparticipantswithevents");
                });

            modelBuilder.Entity("SporEtkinlikleriYonetimSistemi.Models.PastEventsViewModel", b =>
                {
                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EventID")
                        .HasColumnType("integer");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("eventdescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("eventtitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("organizername")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable((string)null);

                    b.ToView("PastEventsView", (string)null);
                });

            modelBuilder.Entity("SporEtkinlikleriYonetimSistemi.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("User");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SporEtkinlikleriYonetimSistemi.Models.Venue", b =>
                {
                    b.Property<int>("VenueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VenueID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("VenueID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("unique_venue_name");

                    b.ToTable("Venues", t =>
                        {
                            t.HasCheckConstraint("chk_venue_capacity", "Capacity > 0");
                        });
                });

            modelBuilder.Entity("SporEtkinlikleriYonetimSistemi.Models.Event", b =>
                {
                    b.HasOne("SporEtkinlikleriYonetimSistemi.Models.User", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("SporEtkinlikleriYonetimSistemi.Models.EventParticipant", b =>
                {
                    b.HasOne("SporEtkinlikleriYonetimSistemi.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SporEtkinlikleriYonetimSistemi.Models.User", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("SporEtkinlikleriYonetimSistemi.Models.EventSchedule", b =>
                {
                    b.HasOne("SporEtkinlikleriYonetimSistemi.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("SporEtkinlikleriYonetimSistemi.Models.Participant", b =>
                {
                    b.HasOne("SporEtkinlikleriYonetimSistemi.Models.Event", "Event")
                        .WithMany("Participants")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("SporEtkinlikleriYonetimSistemi.Models.Event", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
