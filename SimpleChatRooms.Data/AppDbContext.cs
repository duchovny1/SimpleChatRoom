namespace SimpleChatRooms.Data
{
    using Microsoft.EntityFrameworkCore;
    using SimpleChatRooms.Data.Models;

    public class AppDbContext : DbContext
    {
        private  const string ConnectionString = "Server=DESKTOP-L4J6POG;Database=ChatRoomApp;Integrated Security=true";
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
