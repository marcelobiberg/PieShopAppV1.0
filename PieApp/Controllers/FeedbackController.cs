using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PieApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace PieApp.Controllers
{
    //somente autorizado via log in, only registered users made feedback
    [Authorize] //microsoft authorization
    public class FeedbackController : Controller
    {
        //dependencia do repositoty IFeedbackRepository
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _feedbackRepository.AddFeedback(feedback);
                return RedirectToAction("FeedbackComplete");
            }
            return View(feedback);
   
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }
    }
}
