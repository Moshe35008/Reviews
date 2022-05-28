using Microsoft.AspNetCore.Mvc;
using Reviews.Models;
using Reviews.Services;

namespace Reviews.Controllers
{
    public class MyReviewsController : Controller
    {
        private IReviewService service;
        static double average = 0;
        public MyReviewsController()
        {
            service = new ReviewService();       
        }
        public IActionResult Index()
        {
            return View(service.GetAll());
        }
       



        public IActionResult Details(int id)
        {
            return View(service.Get(id));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, int rank, string description)
        {
            service.Create(name, rank, description);
            
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id) { 
        
            return View(service.Get(id));
        }
        [HttpPost]
        public IActionResult Edit(int id, string name, int rank, string description)
        {
            service.Edit(id, name, rank, description);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {

            return View(service.Get(id));
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteForRealsis(int id)
        {
            service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult IndexForFind(List<Review> found)
        {
            return View(found);
        }
        public IActionResult Find(string name)
        {
            
            return View(service.FindByName(name));
        }
        


    }
}
