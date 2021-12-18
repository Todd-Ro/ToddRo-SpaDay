using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        static string mostRecentUsername;
        public IActionResult Index()
        {
            ViewBag.username = mostRecentUsername;
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/User/Add")]
        public IActionResult SubmitAddUserForm(
            //User newUser, 
            string verify
            , string username, string email, string password
            )
        {
            User newUser = new User(username, email, password);
            if (verify.Equals(newUser.Password))
            {
                mostRecentUsername = newUser.Username;
                ViewBag.username = newUser.Username;
                return View("Index");
            } else
            {
                return Redirect("/User/Add");
            }
        }
    }
}
