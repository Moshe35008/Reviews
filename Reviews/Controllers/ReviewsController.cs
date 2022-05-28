using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reviews.Data;
using Reviews.Models;
using Reviews.Services;

namespace Reviews.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService service;

        public ReviewsController()
        {
            service = new ReviewService();
        }

        // GET: Reviews
        public  IActionResult Index()
        {
            return View( service.GetAll());
        }

        // GET: Reviews/Details/5
        public  IActionResult Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var review =  (service.Get((int)id));

            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Rank,Description,CreatedDate")] Review review)
        {
            if (ModelState.IsValid)
            {
                service.Create(review.Name, review.Rank, review.Description);
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        // GET: Reviews/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = service.Get((int)id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Id,Name,Rank,Description,CreatedDate")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    service.Edit(id, review.Name, review.Rank, review.Description);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = service.Get((int)id);               ;
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (service.Get(id) == null)
            {
                return Problem("Entity set 'ReviewsContext.Review'  is null.");
            }
            var review =  service.Get(id);
            if (review != null)
            {
                service.Delete(id);
            }
            
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Find(string name)
        {
            return View(service.FindByName(name));
        }


    }
    
}
