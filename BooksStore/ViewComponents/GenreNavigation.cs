using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Models;
namespace BooksStore.ViewComponents
{
    public class GenreNavigation : ViewComponent
    {
        private IBooksStoreRepository repository;
        public GenreNavigation(IBooksStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.Books
            .Select(x => x.Genre)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}