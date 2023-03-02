using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mission9_giuliani.Models;
using mission9_giuliani.Models.ViewModels;

namespace mission9_giuliani.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository val) => repo = val;

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var booksViewModel = new BooksViewModel
            {
                Books = repo.Books
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize), 

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum 
                }
            };

            return View(booksViewModel);
        }
    }
}
