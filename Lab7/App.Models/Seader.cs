using Microsoft.EntityFrameworkCore;

namespace App.Models;


public static class Seeder
{
    public static async Task SeedAsync(SpecialistBookshopDbContext dbContext)
    {

        await dbContext.Database.MigrateAsync();

        // Seed Authors
        if (!await dbContext.Authors.AnyAsync())
        {
            var authors = new List<Author>
            {
                new Author
                {
                    AuthorFirstName = "John",
                    AuthorInitials = "J.",
                    AuthorLastName = "Doe",
                    AuthorDateOfBirth = new DateTime(1970, 1, 1),
                    AuthorGenderMFU = 1,
                    AuthorContactDetails = "john.doe@example.com",
                    AuthorOtherDetails = "Renowned author"
                },
                new Author
                {
                    AuthorFirstName = "Jane",
                    AuthorInitials = "J.",
                    AuthorLastName = "Smith",
                     AuthorDateOfBirth = new DateTime(1975, 5, 15),
                    AuthorGenderMFU = 2,
                    AuthorContactDetails = "jane.smith@example.com",
                    AuthorOtherDetails = "Award-winning novelist"
                }
            };

            await dbContext.Authors.AddRangeAsync(authors);
            await dbContext.SaveChangesAsync();
        }

        // Seed Book Categories
        if (!await dbContext.BookCategories.AnyAsync())
        {
            var bookCategories = new List<BookCategory>
            {
                new BookCategory
                {
                    BookCategoryDescription = "Fiction"
                },
                new BookCategory
                {
                    BookCategoryDescription = "Non-Fiction"
                },
                new BookCategory
                {
                    BookCategoryDescription = "Biography"
                }
            };

            await dbContext.BookCategories.AddRangeAsync(bookCategories);
            await dbContext.SaveChangesAsync();
        }

        // Seed Books
        if (!await dbContext.Books.AnyAsync())
        {
            var books = new List<Book>
            {
                new Book
                {
                    AuthorId = (await dbContext.Authors.FirstAsync(a => a.AuthorFirstName == "John" && a.AuthorLastName == "Doe")).AuthorId,
                    BookCategoryCode = (await dbContext.BookCategories.FirstAsync(bc => bc.BookCategoryDescription == "Fiction")).BookCategoryCode,
                    ISBN = "978-1-23456-789-0",
                    DateOfPublication = new DateTime(2022, 6, 1),
                    DateAcquired = new DateTime(2022, 6, 15),
                    BookTitle = "The Mysterious Affair",
                    BookRecommendedPrice = 19.99m,
                    BookComments = "Bestselling mystery novel"
                },
                new Book
                {
                    AuthorId = (await dbContext.Authors.FirstAsync(a => a.AuthorFirstName == "Jane" && a.AuthorLastName == "Smith")).AuthorId,
                    BookCategoryCode = (await dbContext.BookCategories.FirstAsync(bc => bc.BookCategoryDescription == "Non-Fiction")).BookCategoryCode,
                    ISBN = "978-0-98765-432-1",
                    DateOfPublication = new DateTime(2021, 3, 15),
                    DateAcquired = new DateTime(2021, 4, 1),
                    BookTitle = "The Art of Storytelling",
                    BookRecommendedPrice = 24.99m,
                    BookComments = "Acclaimed guide on creative writing"
                }
            };

            await dbContext.Books.AddRangeAsync(books);
            await dbContext.SaveChangesAsync();
        }

        // Seed Customers
        if (!await dbContext.Customers.AnyAsync())
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    CustomerCode = "CUST001",
                    CustomerName = "John Doe",
                    CustomerAddress = "123 Main St, Anytown USA",
                    CustomerPhone = "555-1234",
                    CustomerEmail = "john.doe@example.com"
                },
                new Customer
                {
                    CustomerCode = "CUST002",
                    CustomerName = "Jane Smith",
                    CustomerAddress = "456 Oak Rd, Othertown USA",
                    CustomerPhone = "555-5678",
                    CustomerEmail = "jane.smith@example.com"
                }
            };

            await dbContext.Customers.AddRangeAsync(customers);
            await dbContext.SaveChangesAsync();
        }

        // Seed Orders
        if (!await dbContext.Orders.AnyAsync())
        {
            var orders = new List<Order>
            {
                new Order
                {
                    CustomerId = (await dbContext.Customers.FirstAsync(c => c.CustomerName == "John Doe")).CustomerId,
                    OrderDate = new DateTime(2023, 4, 1),
                    OrderValue = 19.99m
                },
                new Order
                {
                    CustomerId = (await dbContext.Customers.FirstAsync(c => c.CustomerName == "Jane Smith")).CustomerId,
                    OrderDate = new DateTime(2023, 5, 15),
                    OrderValue = 24.99m
                }
            };

            await dbContext.Orders.AddRangeAsync(orders);
            await dbContext.SaveChangesAsync();
        }

        // Seed Order Items
        if (!await dbContext.OrderItems.AnyAsync())
        {
            // Get required data asynchronously
            var johnDoeCustomerId = (await dbContext.Customers.FirstAsync(c => c.CustomerName == "John Doe")).CustomerId;
            var johnDoeOrderId = (await dbContext.Orders.FirstAsync(o => o.CustomerId == johnDoeCustomerId)).OrderId;
            var johnDoeBookId = (await dbContext.Books.FirstAsync(b => b.BookTitle == "The Mysterious Affair")).BookId;

            var janeSmithCustomerId = (await dbContext.Customers.FirstAsync(c => c.CustomerName == "Jane Smith")).CustomerId;
            var janeSmithOrderId = (await dbContext.Orders.FirstAsync(o => o.CustomerId == janeSmithCustomerId)).OrderId;
            var janeSmithBookId = (await dbContext.Books.FirstAsync(b => b.BookTitle == "The Art of Storytelling")).BookId;

            // Prepare order items
            var orderItems = new List<OrderItem>
    {
        new OrderItem
        {
            OrderId = johnDoeOrderId,
            BookId = johnDoeBookId,
            ItemAgreedPrice = 19.99m,
            ItemComment = "Mystery novel"
        },
        new OrderItem
        {
            OrderId = janeSmithOrderId,
            BookId = janeSmithBookId,
            ItemAgreedPrice = 24.99m,
            ItemComment = "Non-fiction book on creative writing"
        }
    };

            // Save to database
            await dbContext.OrderItems.AddRangeAsync(orderItems);
            await dbContext.SaveChangesAsync();
        }

        // Seed Ref Contact Types
        if (!await dbContext.RefContactTypes.AnyAsync())
        {
            var refContactTypes = new List<RefContactType>
            {
                new RefContactType
                {
                    ContactTypeDescription = "Work Phone"
                },
                new RefContactType
                {
                    ContactTypeDescription = "Cell Phone"
                },
                new RefContactType
                {
                    ContactTypeDescription = "Other"
                }
            };

            await dbContext.RefContactTypes.AddRangeAsync(refContactTypes);
            await dbContext.SaveChangesAsync();
        }

        // Seed Contacts
        if (!await dbContext.Contacts.AnyAsync())
        {
            var contacts = new List<Contact>
    {
        new Contact
        {
            ContactTypeCode = (await dbContext.RefContactTypes.FirstAsync(rct => rct.ContactTypeDescription == "Work Phone")).ContactTypeCode,
            ContactFirstName = "John",
            ContactLastName = "Doe",
            ContactWorkPhoneNumber = "555-1234",
            ContactCellPhoneNumber = "555-0001", // Обов'язкове поле
            ContactOtherDetails = "Primary contact"
        },
        new Contact
        {
            ContactTypeCode = (await dbContext.RefContactTypes.FirstAsync(rct => rct.ContactTypeDescription == "Cell Phone")).ContactTypeCode,
            ContactFirstName = "Jane",
            ContactLastName = "Smith",
            ContactWorkPhoneNumber =  "555-5678", 
            ContactCellPhoneNumber = "555-5678", // Обов'язкове поле
            ContactOtherDetails = "Secondary contact"
        }
    };

            await dbContext.Contacts.AddRangeAsync(contacts);
            await dbContext.SaveChangesAsync();
        }
    }
}
