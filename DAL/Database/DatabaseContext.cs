using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DAL.Domain;
namespace DAL.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("MyDigitalizingCensusDB")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<HouseMember> HouseMembers { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<UserCurrentRequestStatus> UserCurrentRequestStatus{get;set;}


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
