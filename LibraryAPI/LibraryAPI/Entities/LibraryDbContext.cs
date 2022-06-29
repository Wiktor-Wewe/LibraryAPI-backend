using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Entities
{
    public class LibraryDbContext : DbContext
    {
        private string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;";
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired();

            modelBuilder.Entity<Author>()
                .Property(a => a.FirstName)
                .IsRequired();

            modelBuilder.Entity<Author>()
                .Property(a => a.Surname)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
