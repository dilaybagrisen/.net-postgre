using Microsoft.EntityFrameworkCore;
using SporEtkinlikleriYonetimSistemi.Models;

namespace SporEtkinlikleriYonetimSistemi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        
        public DbSet<Participant> Participants { get; set; } // Yeni katılımcılar tablosu
        public DbSet<Venue> Venues { get; set; }
        public DbSet<EventSchedule> EventSchedules { get; set; }

        public DbSet<EventParticipant> EventParticipants { get; set; }

        public DbSet<PastEventsViewModel> PastEventsViews { get; set; }

        public DbSet<ParticipantWithEventViewModel> ParticipantWithEventViewModels { get; set; }

        public DbSet<TopEventViewModel> TopEventViewModel { get; set; }



        public DbSet<UpcomingModel> upcomingModels { get; set; }

        public DbSet<EventsByOrganizerViewModel> EventsByOrganizerViewModel { get; set; }

        public DbSet<EventDurationStatsViewModel> EventDurationStatsView { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Event>()
          .HasCheckConstraint("chk_event_dates", "\"StartDate\" < \"EndDate\"");

            

            // Benzersiz Mekan İsmi
            modelBuilder.Entity<Venue>()
               .HasIndex(v => v.Name)
              .IsUnique()
               .HasDatabaseName("unique_venue_name");

            // Varsayılan Kullanıcı Rolü
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasDefaultValue("User");

            // Mekan Kapasite Kısıtlaması
             modelBuilder.Entity<Venue>()
                  .HasCheckConstraint("chk_venue_capacity", "Capacity > 0");



            modelBuilder.Entity<Participant>().HasOne(x => x.Event).WithMany(x => x.Participants).HasForeignKey(x => x.EventID);


            modelBuilder.Ignore<PastEventsViewModel>();
            modelBuilder.Entity<PastEventsViewModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("PastEventsView");
            });

            modelBuilder.Ignore<ParticipantWithEventViewModel>();

            modelBuilder.Entity<ParticipantWithEventViewModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToFunction("getparticipantswithevents");
            });


            modelBuilder.Ignore<TopEventViewModel>();
            modelBuilder.Entity<TopEventViewModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToFunction("GetTop5EventsByParticipants");
            });



            modelBuilder.Ignore<UpcomingModel>();
            modelBuilder.Entity<UpcomingModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("UpcomingEventsView");
            });


            modelBuilder.Ignore<EventsByOrganizerViewModel>();
            modelBuilder.Entity<EventsByOrganizerViewModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("EventsByOrganizerView");
            });


            modelBuilder.Ignore<EventDurationStatsViewModel>();
            modelBuilder.Entity<EventDurationStatsViewModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("EventDurationStatsView");
            });

            base.OnModelCreating(modelBuilder);
        }


       
        
            



    }
}
