using System.Linq;
namespace BooksStore.Models
{
    public interface IBooksStoreRepository
    {
        IQueryable<Book> Books { get; }
        void SaveBook(Book b);
        void CreateBook(Book b);
        void DeleteBook(Book b);
    }
}