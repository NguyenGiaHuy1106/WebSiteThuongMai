using Microsoft.AspNetCore.Mvc;
using BooksStore.Models;
using System.Linq;
using BooksStore.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly BooksStoreDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly BooksStoreDbContext _context;
        private IBooksStoreRepository repository;
        public int PageSize = 3;
        public HomeController(IBooksStoreRepository repo, BooksStoreDbContext context, IWebHostEnvironment hostEnvironment)
        {
            repository = repo;
            dbContext = context;
            webHostEnvironment = hostEnvironment;
            _context = context;
        }
        public IActionResult Index(string genre, int bookPage = 1)
            => View(new BooksListViewModel
            {

                Books = repository.Books
                    .Where(p => genre == null || p.Genre == genre)
                    .OrderBy(b => b.BookID)
                    .Skip((bookPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = bookPage,
                    ItemsPerPage = PageSize,
                    TotalItems = genre == null ?
                    repository.Books.Count() : repository.Books.Where(e => e.Genre == genre).Count()

                },
                CurrentGenre = genre
            });
        public IActionResult Created()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Created(BooksViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Book book = new Book
                {

                    Title = model.Title,
                    Description = model.Description,
                    Genre = model.Genre,
                    Price = model.Price,
                    ProfilePicture = uniqueFileName,
                };
                dbContext.Add(book);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        private string UploadedFile(BooksViewModel model)
        {
            string uniqueFileName = null;

            if (model.ImageBook != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageBook.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageBook.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}