namespace CalgaryHacks.DatabaseModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
