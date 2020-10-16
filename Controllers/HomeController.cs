using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using activitycenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace activitycenter.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbcontext;
        public HomeController(MyContext context)
        {
            dbcontext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("CurrentUser") != null)
            {
                return RedirectToAction("Dashboard");
            }
            else{
                return View();
            }
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                if(dbcontext.Users.FirstOrDefault(u => u.Email == user.Email) != null)
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("index");
                }
                if(user.Password.Any(c => char.IsLetter(c)) == false)
                {
                    ModelState.AddModelError("Password", "Password Must Contain a Letter");
                    return View("index");
                }
                if(user.Password.Any(c => char.IsDigit(c)) == false)
                {
                    ModelState.AddModelError("Password", "Password Must Contain a Number");
                    return View("index");
                }
                if(user.Password.Any(c => char.IsPunctuation(c)) == false)
                {
                    ModelState.AddModelError("Password", "Password Must Contain a Symbol");
                    return View("index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                dbcontext.Users.Add(user);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("index");
        }
        [HttpPost("login")]
        public IActionResult Login(string Email, string Password)
        {
            var userInDb = dbcontext.Users.FirstOrDefault(u => u.Email == Email);
            if(userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("index");
            }
            var hasher = new PasswordHasher<string>();
            var result = hasher.VerifyHashedPassword(Password, userInDb.Password, Password);
            if (result == 0)
            {
                ModelState.AddModelError("Password", "Invalid Email/Password");
                return View("index");
            }
            else{
                HttpContext.Session.SetInt32("CurrentUser", userInDb.UserId);
                return RedirectToAction("Dashboard");
            }
        }
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetInt32("CurrentUser") == null)
            {
                ModelState.AddModelError("Login", "User not logged in");
                return View("Index");
            }
            User user = dbcontext.Users.Include(u => u.Activities).FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("CurrentUser"));
            ViewBag.Activities = dbcontext.Activities.Include(a => a.Coordinator).Include(a => a.Participants).OrderBy(a => a.Date).ToList();
            ViewBag.valid = false;
            return View(user);
        }
        [HttpGet("add")]
        public IActionResult Add()
        {
            if(HttpContext.Session.GetInt32("CurrentUser") == null)
            {
                ModelState.AddModelError("Login", "User not logged in");
                return View("Index");
            }
            return View();
        }
        [HttpPost("add/verify")]
        public IActionResult AddActivity(AnActivity newactivity)
        {
            User user = dbcontext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("CurrentUser"));
            newactivity.UserID = user.UserId;
            newactivity.Coordinator = user;
            if(ModelState.IsValid)
            {
                if(newactivity.Date.Month < DateTime.Today.Month)
                {
                    ModelState.AddModelError("Date", "Date is not in the future");
                    return View("add");
                }
                if(newactivity.Date.Month == DateTime.Today.Month && newactivity.Date.Day <= DateTime.Today.Day)
                {
                    ModelState.AddModelError("Date", "Activities must be added at prior to the date of the activity");
                    return View("add");
                }
                dbcontext.Activities.Add(newactivity);
                dbcontext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("add");
        }
        [HttpGet("{id}/join")]
        public IActionResult Join(int id)
        {
            User joinuser = dbcontext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("CurrentUser"));
            UserActivity joiner = new UserActivity(){
                UserID = joinuser.UserId,
                user = joinuser,
                AnActivityID = id,
                anActivity = dbcontext.Activities.FirstOrDefault(a => a.AnActivityId == id)
            };
            dbcontext.UserActivities.Add(joiner);
            dbcontext.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet("{id}/leave")]
        public IActionResult Leave(int id)
        {
            UserActivity leave = dbcontext.UserActivities.FirstOrDefault(u => u.UserID == HttpContext.Session.GetInt32("CurrentUser") && u.AnActivityID == id);
            
            dbcontext.UserActivities.Remove(leave);
            dbcontext.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet("{id}/delete")]
        public IActionResult Delete(int id)
        {
            User user = dbcontext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("CurrentUser"));
            AnActivity deleter = dbcontext.Activities.FirstOrDefault(u => u.AnActivityId == id);
            if(deleter.Coordinator != user)
            {
                return RedirectToAction("Dashboard");
            }
            dbcontext.Activities.Remove(deleter);
            dbcontext.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet("{id}")]
        public IActionResult DisplayActivity(int id)
        {
            AnActivity display = dbcontext.Activities.Include(a => a.Coordinator).Include(a => a.Participants).ThenInclude(ua => ua.user).FirstOrDefault(u => u.AnActivityId == id);
            ViewBag.User = dbcontext.Users.Include(u => u.Activities).FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("CurrentUser"));
            ViewBag.Valid = false;
            return View(display);
        }
        public IActionResult Privacy()
        {
            return View();
            
        }

    }
}
