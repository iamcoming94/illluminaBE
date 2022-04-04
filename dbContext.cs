using Microsoft.EntityFrameworkCore;

namespace pb
{
    public class dbContext : DbContext
    {
        private const string connectionString = "Server=tcp:jslearning.database.windows.net,1433;Initial Catalog=myLearning;Persist Security Info=False;User ID=jinsheng;Password=Iamcoming940401;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<PhoneBook> PhoneBooks { get; set; }
    }
}
