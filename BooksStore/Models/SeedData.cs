using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace BooksStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            BooksStoreDbContext context =
           app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService < BooksStoreDbContext > ();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                new Book
                {
                    Title = "Kể Chuyện Văn Hoá Việt - Chuyện Ở Của Người Xưa",
                    Description = "An Easy & Proven Way to Build Good Habits & Break Bad Ones",
               
                    Genre = "Self-Help",
                    Price = 11.98m
                },
                new Book
                {
                    Title = "How to Win Friends & Influence People",
                    Description = "You can go after the job you want...and get it! You can take the job you have...and improve it!",
               
                    Genre = "Self-Help",
                    Price = 17.46m
                },
                new Book
                {
                    Title = "Rich Dad Poor Dad",
                    Description = "What the Rich Teach Their Kids About Money That the Poor and Middle Class Do Not!",
               
                    Genre = "Personal Finance",
                    Price = 13.41m
                },
                new Book
                {
                    Title = "The Psychology of Money",
                    Description = "Doing well with money isn’t necessarily about what you know.It’s about how you behave.And behavior is hard to teach, even to really smart people.",
               
                    Genre = "Money Management",
                    Price = 18.69m
                }, 
                new Book
                {
                    Title = "48 Laws of Power",
                    Description = "Amoral, cunning, ruthless, and instructive, this piercing work distills 3, 000 years of the history of power into 48 well - explicated laws.",
               
                    Genre = "Political Science",
                    Price = 31.26m
                }
                );
                context.SaveChanges();
            }
        }
    }
}
