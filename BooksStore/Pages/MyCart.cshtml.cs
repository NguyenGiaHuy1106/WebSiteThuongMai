using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BooksStore.MyTagHelper;
using BooksStore.Models;
using System.Linq;
namespace BooksStore.Pages
{
    public class MyCartModel : PageModel
    {
        private IBooksStoreRepository repository;
        public MyCartModel(IBooksStoreRepository repo, MyCart myCartService)
        {
            repository = repo;
            myCart = myCartService;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books
            .FirstOrDefault(b => b.BookID == bookId);
            myCart.AddItem(book, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            myCart.RemoveLine(myCart.Lines.First(cl =>
            cl.Book.BookID == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}