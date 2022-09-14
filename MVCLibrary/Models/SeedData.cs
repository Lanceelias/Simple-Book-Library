using MVCLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace MVCLibrary.Models
{
    public class SeedData
    {
        /// <summary>
        /// Adding a data in a database that has a existing data.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new LibraryContext(
                serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                if(context.Book.Any())
                {
                    return;
                }

                context.Book.AddRange(
                    new Book { Title = "Tiny C# Projects", CallNumber = "ABC 123", Author = "Ralph" },
                    new Book { Title = "Tiny Android Projects", CallNumber = "ABD 123", Author = "James" }
                    );
                context.SaveChanges();
            }
        }
    }
}
