namespace CalgaryHacks.DatabaseModel
{
    using System.Data.Entity;

    public class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PointsOfInterest> PointsOfInterest { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
