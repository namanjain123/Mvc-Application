using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class TvShowController : Controller
    {
        //Dependency Injection
        private ApplicationDbContext _context;
        public TvShowController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //Created from the data
        
        // GET: TvShow
        public ActionResult Index()
        {
            var tvshows = _context.TvShow.ToList();//GEt all the customer in database
            return View(tvshows);
        }

        // GET: TvShow/Details/5
        public ActionResult Details(int id)
        {
            var tvshow = _context.TvShow.SingleOrDefault(c => c.Show_Id == id);
            if (tvshow == null)
                return HttpNotFound();
            return View(tvshow);
        }

        // GET: TvShow/Create
        public ActionResult Create(TvShow tvshow)
        {
            if (tvshow.Show_Id == 0)
            {
                _context.TvShow.Add(tvshow);

            }
            else
            {
                var tvshowInDb = _context.TvShow.Single(c => c.Show_Id == tvshow.Show_Id);
                tvshowInDb.Name = tvshow.Name;
                tvshowInDb.Duration = tvshow.Duration;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "TvShow");
        }

        public ActionResult New()
        {
            
            var viewModel = new TvShowViewModel
            {
            };
            return View(viewModel);
        }

        // GET: TvShow/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _context.TvShow.SingleOrDefault(c => c.Show_Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new TvShowViewModel
            {
                TvShow=customer
            };

            return View("New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(TvShow TvShow) 
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TvShowViewModel { };

                return View("new", viewModel);
            }
            
            if (TvShow.Show_Id == 0)
            {
                TvShow.Duration = TimeSpan.Zero;
                _context.TvShow.Add(TvShow);
            }
            else
            {
                var TvShowInDb = _context.TvShow.Single(m => m.Show_Id == TvShow.Show_Id);
                TvShowInDb.Name = TvShow.Name;
                TvShowInDb.Duration = TvShow.Duration;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "TvShow");
        }
    }
}
