using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Data.Models.Mapping;

namespace Data.Models
{
    public partial class didon_dbContext : DbContext
    {
        static didon_dbContext()
        {
            Database.SetInitializer<didon_dbContext>(null);
        }

        public didon_dbContext()
            : base("Name=didon_dbContext")
        {
        }

        public DbSet<baggage> baggages { get; set; }
        public DbSet<bus> buses { get; set; }
        public DbSet<car> cars { get; set; }
        public DbSet<carbooking> carbookings { get; set; }
        public DbSet<carrentalagency> carrentalagencies { get; set; }
        public DbSet<flight> flights { get; set; }
        public DbSet<flight_freeplacesmap> flight_freeplacesmap { get; set; }
        public DbSet<flight_pricemap> flight_pricemap { get; set; }
        public DbSet<meal> meals { get; set; }
        public DbSet<plane> planes { get; set; }
        public DbSet<provider> providers { get; set; }
        public DbSet<runway> runways { get; set; }
        public DbSet<staff> staffs { get; set; }
        public DbSet<ticket> tickets { get; set; }
        public DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new baggageMap());
            modelBuilder.Configurations.Add(new busMap());
            modelBuilder.Configurations.Add(new carMap());
            modelBuilder.Configurations.Add(new carbookingMap());
            modelBuilder.Configurations.Add(new carrentalagencyMap());
            modelBuilder.Configurations.Add(new flightMap());
            modelBuilder.Configurations.Add(new flight_freeplacesmapMap());
            modelBuilder.Configurations.Add(new flight_pricemapMap());
            modelBuilder.Configurations.Add(new mealMap());
            modelBuilder.Configurations.Add(new planeMap());
            modelBuilder.Configurations.Add(new providerMap());
            modelBuilder.Configurations.Add(new runwayMap());
            modelBuilder.Configurations.Add(new staffMap());
            modelBuilder.Configurations.Add(new ticketMap());
            modelBuilder.Configurations.Add(new userMap());
        }
    }
}
