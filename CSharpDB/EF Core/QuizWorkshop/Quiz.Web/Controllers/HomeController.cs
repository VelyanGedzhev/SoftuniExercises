using Microsoft.AspNetCore.Mvc;
using Quiz.Services;
using Quiz.Web.Models;
using System.Diagnostics;

namespace Quiz.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuizService quizService;

        public HomeController(IQuizService quizService)
        {
            this.quizService = quizService;
        }

        public IActionResult Index()
        {
            var username = this.User?.Identity?.Name;
            var userQuizzes = this.quizService.GetQuizzesByUserName(username);

            return View(userQuizzes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
