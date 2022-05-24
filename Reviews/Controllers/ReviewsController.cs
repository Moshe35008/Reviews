using Microsoft.AspNetCore.Mvc;
using Reviews.Models;

namespace Reviews.Controllers
{
    public class ReviewsController : Controller
    {
        private static List<Review> reviews = new List<Review>();
        static double average = 0;
        public ReviewsController()
        {
          
           
        }
        public IActionResult Index()
        {
            return View(reviews);
        }
       



        public IActionResult Details(int id)
        {
            var review = reviews.Find(x => x.Id == id);
            return View(review);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, int rank, string description)
        {
            int nextId;
            if (reviews.Count != 0)
            {
                nextId= reviews.Max(x => x.Id) + 1;
            }
            else
                nextId= 1;
  


            reviews.Add(new Review() { Id =nextId, Name = name, Rank = rank, Description = description,CreatedDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id) { 

            Review rev = reviews.Find(x => x.Id == id);

        
            return View(rev);
        }
        [HttpPost]
        public IActionResult Edit(int id, string name, int rank, string description)
        {
            Review rev = reviews.Find(x => x.Id == id);
            rev.Name = name;
            rev.Rank = rank;
            rev.CreatedDate = DateTime.Now;
            rev.Description = description;
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {

            Review rev = reviews.Find(x => x.Id == id);


            return View(rev);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteForRealsis(int id)
        {
            Review rev = reviews.Find(x => x.Id == id);
            reviews.Remove(rev);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult IndexForFind(List<Review> found)
        {
            return View(found);
        }
        public IActionResult Find(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
               return View(reviews);
            }
            List<Review> found = new List<Review>();
            for (int i = 0; i < reviews.Count; ++i)
            {
                if (reviews[i].Name.Equals(name))
                    found.Add(reviews[i]);

            }
            return View(found);
        }
        


    }
}
