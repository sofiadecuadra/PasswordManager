using System.Data.Entity;

namespace DataManagerDomain
{
    public class DataManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<UserPasswordPair> UserPasswordPairs { get; set; }
        public DbSet<DataBreach> DataBreaches { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataBreach>()
                .HasKey(dataBreach => dataBreach.DateTime);
            modelBuilder.Entity<User>()
                .HasKey(user => user.Username);
            modelBuilder.Entity<UserPasswordPair>()
                .Property(f => f.LastModifiedDate)
                .HasColumnType("datetime2");
        }
    }
}
