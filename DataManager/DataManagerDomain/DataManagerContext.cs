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
        public DbSet<LeakedCreditCard> LeakedCreditCards { get; set; }
        public DbSet<LeakedPassword> LeakedPasswords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(user => user.Username)
                .Ignore(user => user.MasterPassword); 
            modelBuilder.Entity<UserPasswordPair>()
                .Ignore(userPassPair => userPassPair.Password)
                .Property(f => f.LastModifiedDate)
                .HasColumnType("datetime2");
            modelBuilder.Entity<User>()
                .HasMany<UserPasswordPair>(user => user.SharedPasswords)
                .WithMany(userPasswordPair => userPasswordPair.UsersWithAccess)
                .Map(cs =>
                {
                    cs.ToTable("SharedPasswords");
                });
        }
    }
}
