using System.Data.Entity;

namespace DataManagerDomain
{
    public class DataManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<UserPasswordPair> UserPasswordPairs { get; set; }
        public DbSet<DataBreach> DataBreaches { get; set; }
    }
}
