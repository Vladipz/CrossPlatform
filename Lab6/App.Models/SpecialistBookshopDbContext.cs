using Microsoft.EntityFrameworkCore;

namespace App.Models
{

    public class SpecialistBookshopDbContext : DbContext
    {
        public SpecialistBookshopDbContext(DbContextOptions<SpecialistBookshopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<RefContactType> RefContactTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(static a => a.AuthorId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Book>()
                .Property(static b => b.BookId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Book>()
                .HasOne(static b => b.Author)
                .WithMany()
                .HasForeignKey(static b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne(static b => b.BookCategory)
                .WithMany()
                .HasForeignKey(static b => b.BookCategoryCode);

            modelBuilder.Entity<BookCategory>()
                .Property(static bc => bc.BookCategoryCode)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<BookCategory>()
                .HasKey(static bc => bc.BookCategoryCode);

            modelBuilder.Entity<Customer>()
                .Property(static c => c.CustomerId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Order>()
                .Property(static o => o.OrderId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Order>()
                .HasOne(static o => o.Customer)
                .WithMany()
                .HasForeignKey(static o => o.CustomerId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(static oi => oi.Order)
                .WithMany()
                .HasForeignKey(static oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(static oi => oi.Book)
                .WithMany()
                .HasForeignKey(static oi => oi.BookId);

            _ = modelBuilder.Entity<OrderItem>()
              .HasKey(static oi => oi.ItemNumber);

            modelBuilder.Entity<RefContactType>()
              .Property(static rct => rct.ContactTypeCode)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<RefContactType>()
                .HasKey(static rct => rct.ContactTypeCode);

            modelBuilder.Entity<Contact>()
              .Property(static c => c.ContactId)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<Contact>()
                .HasOne(static c => c.RefContactType)
                .WithMany()
                .HasForeignKey(static c => c.ContactTypeCode);
        }
    }
}
