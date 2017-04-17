
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {

        private RestContext _context;
    
        public HomeController(RestContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index() {
            ViewBag.Errors = TempData["Errors"];
            return View();
        }

        [HttpPost]
        [Route("/add_review")]
        public IActionResult AddReview(Review NewReview) {


            if(ModelState.IsValid) {
                _context.Add(NewReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }

            List<string> allErrors = new List <string>();
            foreach (var i in ModelState.Values) {
                if (i.Errors.Count > 0) {
                    allErrors.Add(i.Errors[0].ErrorMessage.ToString());
                }
            }
            TempData["Errors"] = allErrors;
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews() {

            List<Review> AllReviews = _context.Reviews.OrderBy(review => review.date).ToList();
            ViewBag.AllReviews = AllReviews;
            return View("Reviews");
        }

    }
}
