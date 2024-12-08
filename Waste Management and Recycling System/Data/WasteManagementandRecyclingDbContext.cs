using Microsoft.EntityFrameworkCore;
using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Data
{
    public class WasteManagementandRecyclingDbContext : DbContext
    {
        public WasteManagementandRecyclingDbContext(DbContextOptions<WasteManagementandRecyclingDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<RecyclingPlant> RecyclingPlants { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventVolunteer> EventVolunteers { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Incentive> Incentives { get; set; }
        public DbSet<RecyclingParticipation> RecyclingParticipations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<HazardousWaste> HazardousWastes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.HasMany(e => e.Collections)
                      .WithOne(c => c.Collector)
                      .HasForeignKey(c => c.CollectorId);
                entity.HasMany(e => e.Complaints)
                      .WithOne(c => c.User)
                      .HasForeignKey(c => c.UserId);
                entity.HasMany(e => e.EventsParticipated)
                      .WithOne(v => v.Volunteer)
                      .HasForeignKey(v => v.VolunteerId);
            });
            modelBuilder.Entity<Collection>(entity =>
            {
                entity.HasKey(e => e.CollectionId);
            });

            modelBuilder.Entity<RecyclingPlant>(entity =>
            {
                entity.HasKey(e => e.PlantId);
                entity.HasOne(e => e.Manager)
                      .WithMany()
                      .HasForeignKey(e => e.ManagerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.ReportId);
                entity.HasOne(e => e.Creator)
                      .WithMany()
                      .HasForeignKey(e => e.CreatedBy);
            });
            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.HasKey(e => e.ComplaintId);
            });
            modelBuilder.Entity<Training>(entity =>
            {
                entity.HasKey(e => e.TrainingId);
                entity.HasOne(e => e.Trainer)
                      .WithMany()
                      .HasForeignKey(e => e.TrainerId);
            });
            modelBuilder.Entity<EventVolunteer>(entity =>
            {
                entity.HasKey(ev => new { ev.EventId, ev.VolunteerId });
                entity.HasOne(ev => ev.Event)
                      .WithMany(e => e.RegisteredVolunteers)
                      .HasForeignKey(ev => ev.EventId);
                entity.HasOne(ev => ev.Volunteer)
                      .WithMany(v => v.EventsParticipated)
                      .HasForeignKey(ev => ev.VolunteerId);
            });
            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);
            });
            modelBuilder.Entity<Incentive>(entity =>
            {
                entity.HasKey(e => e.IncentiveId);
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId);
            });
            modelBuilder.Entity<RecyclingParticipation>(entity =>
            {
                entity.HasKey(e => e.ParticipationId);
                entity.HasOne(rp => rp.User)
                      .WithMany()
                      .HasForeignKey(rp => rp.UserId);
            });
            
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.NotificationId);
            });
            modelBuilder.Entity<HazardousWaste>(entity =>
            {
                entity.HasKey(e => e.WasteId);
                entity.HasOne(hw => hw.Collector)
                      .WithMany()
                      .HasForeignKey(hw => hw.CollectorId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(hw => hw.RecyclingPlant)
                      .WithMany()
                      .HasForeignKey(hw => hw.RecyclingPlantId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
