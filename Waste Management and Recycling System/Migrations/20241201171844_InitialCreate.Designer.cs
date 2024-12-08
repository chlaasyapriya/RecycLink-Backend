﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Waste_Management_and_Recycling_System.Data;

#nullable disable

namespace Waste_Management_and_Recycling_System.Migrations
{
    [DbContext(typeof(WasteManagementandRecyclingDbContext))]
    [Migration("20241201171844_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Collection", b =>
                {
                    b.Property<int>("CollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollectionId"));

                    b.Property<int>("CollectorId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PickupDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WasteType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CollectionId");

                    b.HasIndex("CollectorId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Complaint", b =>
                {
                    b.Property<int>("ComplaintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComplaintId"));

                    b.Property<DateTime>("DateReported")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("IssueType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResolutionStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ComplaintId");

                    b.HasIndex("UserId");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.HazardousWaste", b =>
                {
                    b.Property<int>("WasteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WasteId"));

                    b.Property<int>("CollectorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCollected")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DisposalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisposalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FacilityId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WasteId");

                    b.HasIndex("CollectorId");

                    b.HasIndex("FacilityId");

                    b.ToTable("HazardousWastes");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Incentive", b =>
                {
                    b.Property<int>("IncentiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncentiveId"));

                    b.Property<int>("PointsEarned")
                        .HasColumnType("int");

                    b.Property<DateTime>("RedemptionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RewardType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("IncentiveId");

                    b.HasIndex("UserId");

                    b.ToTable("Incentives");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.RecyclingPlant", b =>
                {
                    b.Property<int>("PlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantId"));

                    b.Property<double>("Capacity")
                        .HasColumnType("float");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessedMaterials")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlantId");

                    b.HasIndex("ManagerId");

                    b.ToTable("RecyclingPlants");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Report", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportId"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GeneratedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReportType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReportId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResourceId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MaintenanceDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResourceId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Training", b =>
                {
                    b.Property<int>("TrainingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainingId"));

                    b.Property<string>("AudienceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateScheduled")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("TrainingId");

                    b.HasIndex("TrainerId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Volunteer", b =>
                {
                    b.Property<int>("VolunteerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VolunteerId"));

                    b.Property<string>("EventsParticipated")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("TotalHoursWorked")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("VolunteerId");

                    b.HasIndex("UserId");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Collection", b =>
                {
                    b.HasOne("Waste_Management_and_Recycling_System.Models.User", "Collector")
                        .WithMany("Collections")
                        .HasForeignKey("CollectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collector");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Complaint", b =>
                {
                    b.HasOne("Waste_Management_and_Recycling_System.Models.User", "User")
                        .WithMany("Complaints")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.HazardousWaste", b =>
                {
                    b.HasOne("Waste_Management_and_Recycling_System.Models.User", "Collector")
                        .WithMany()
                        .HasForeignKey("CollectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Waste_Management_and_Recycling_System.Models.RecyclingPlant", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Collector");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Incentive", b =>
                {
                    b.HasOne("Waste_Management_and_Recycling_System.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Notification", b =>
                {
                    b.HasOne("Waste_Management_and_Recycling_System.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.RecyclingPlant", b =>
                {
                    b.HasOne("Waste_Management_and_Recycling_System.Models.User", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Report", b =>
                {
                    b.HasOne("Waste_Management_and_Recycling_System.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Training", b =>
                {
                    b.HasOne("Waste_Management_and_Recycling_System.Models.User", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.Volunteer", b =>
                {
                    b.HasOne("Waste_Management_and_Recycling_System.Models.User", "User")
                        .WithMany("VolunteerRecords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Waste_Management_and_Recycling_System.Models.User", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("Complaints");

                    b.Navigation("VolunteerRecords");
                });
#pragma warning restore 612, 618
        }
    }
}