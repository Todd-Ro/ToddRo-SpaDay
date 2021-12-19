using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;
using System;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        static string mostRecentUsername;
        static DateTime mostRecentJoinDate;

        static string StringOfDate(DateTime dt)
        {
            string joinDateString = dt.Year.ToString() + "-"
                + dt.Month.ToString() + "-"
                + dt.Day.ToString();
            return joinDateString;
        }

        public IActionResult Index()
        {
            ViewBag.username = mostRecentUsername;
            string joinDateString = StringOfDate(mostRecentJoinDate);
            ViewBag.joindate = joinDateString;
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/User")]
        public IActionResult SubmitAddUserForm(User newUser, string verify
            , string username, string email)
        {
            //, string password
            //User newUser = new User(username, email, password);
            ViewBag.username = username;
            if (verify.Equals(newUser.Password))
            {
                mostRecentUsername = newUser.Username;
                mostRecentJoinDate = newUser.TimeJoined.Date;
                string joinDateString = StringOfDate(mostRecentJoinDate);
                ViewBag.joindate = joinDateString;
                return View("Index");
            } else
            {
                string error = "Password and verify do not match. Please try again.";
                ViewBag.passwordmatchmsg = error;
                ViewBag.email = email;
                return View("Add");
                //return Redirect("/User/Add");
            }
        }
    }
}
