using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreContext>>()))
            {
                if (context.Books.Any())    // Check if database contains any books
                {
                    return;     // Database contains books already
                }

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Bröderna Lejonhjärta",
                        Language = "Swedish",
                        ISBN = "9789129688313",
                        DatePublished = DateTime.Parse("2013-9-26"),
                        Price = 139,
                        Author = "Astrid Lindgren",
                        ImageUrl = "/images/lejonhjärta.jpg"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
