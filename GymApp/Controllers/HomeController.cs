using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GymApp.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using GymApp.Database;
using GymApp.Utils;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GymDbContext _gymDb;

        public HomeController(ILogger<HomeController> logger, GymDbContext gymDb)
        {
            _gymDb = gymDb;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var gyms = _gymDb.Gyms.Include(c => c.Opinions);
            var gymsViewModel = new List<GymViewModel>();
            foreach (var gym in gyms)
            {
                gymsViewModel.Add(new GymViewModel()
                {
                    Name = gym.Name,
                    Description = gym.Description,
                    Id = gym.Id,
                    Image = gym.ImageUrl,
                    NumberOfOpinions = gym.Opinions.Count()
                });
            }

            return View(gymsViewModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(string username, string password, string repeatPassword)
        {
            var errors = new List<string>();
            if (username == null || username.Length == 0)
            {
                errors.Add("Username is required.");
            }
            else if (_gymDb.Users.ToList().Find(user => user.Login == username) != null)
            {
                return View(SignupViewModel.newErrorInstance("A user with that name already exists"));
            }
            else if (username.Length < 3)
            {
                errors.Add("Username too short.");
            }
            if (password == null || password.Length == 0)
            {
                errors.Add("Password is required.");
            }
            else if (password.Length < 8)
            {
                errors.Add("Password too short.");
            }
            else if (password != repeatPassword)
            {
                errors.Add("Different passwords were provided.");
            }

            if (errors.Count > 0)
            {
                return View(SignupViewModel.newErrorInstance(string.Join(' ', errors)));
            }
            else
            {
                var user = new User(username, Cypher.sha256Hash(password));
                _gymDb.Users.Add(user);
                _gymDb.SaveChanges();
                return View(SignupViewModel.newSuccessInstance(username));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string returnUrl)
        {
            if (username == null || username.Length == 0 || password == null || password.Length == 0)
            {
                return View(new LoginViewModel("All fields are required."));
            }
            var user = _gymDb.Users.ToList().Find(x => x.Login == username);
            if (user == null) return View(new LoginViewModel("Incorrect data entered."));
            if (user.Password == Cypher.sha256Hash(password))
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect(returnUrl != null ? returnUrl : "/");
            }
            else
            {
                return View(new LoginViewModel("Incorrect data entered."));
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
