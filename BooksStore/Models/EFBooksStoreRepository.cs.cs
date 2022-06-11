using System.Linq;
namespace BooksStore.Models
{
    public class EFBooksStoreRepository : IBooksStoreRepository
    {
        private BooksStoreDbContext context;
        public EFBooksStoreRepository(BooksStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Book> Books => context.Books;
        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }
        public void DeleteBook(Book b)
        {
            context.Remove(b); context.SaveChanges();
        }
        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }
    }
}