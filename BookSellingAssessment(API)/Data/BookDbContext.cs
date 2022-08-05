using BookSellingAssessment_API_.Model;
using Microsoft.EntityFrameworkCore;

namespace BookSellingAssessment_API_.Data
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> BookDetails { get; set; }

        public BookDbContext()
        {

        }

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0LKSRK2;Initial Catalog=BookSelling;Integrated Security=True");
        }

    }
}
