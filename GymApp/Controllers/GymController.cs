using GymApp.Database;
using GymApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Controllers
{
    public class GymController : Controller
    {
        private readonly GymDbContext gymDbContext;

        public GymController(GymDbContext gymDbContext)
        {
            this.gymDbContext = gymDbContext;
        }

        // GET: GymController/Details/5
        public ActionResult Details(int id)
        {

            var gym = gymDbContext.Gyms.Include(d => d.Opinions).FirstOrDefault(c => c.Id == id);

            return View("Index", gym);
        }

        // GET: GymController/Create
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOpinion([FromBody] OpinionViewModel opinion)
        {
            if (opinion.GymId > 0 && !string.IsNullOrEmpty(opinion.Opinion))
            {
                var gym = gymDbContext.Gyms.FirstOrDefault(c => c.Id == opinion.GymId);
                if(gym != null)
                {
                    gym.Opinions.Add(new GymOpinion()
                    {
                        Author = User.Identity.Name,
                        Created = DateTime.Now,
                        IsVisible = true,
                        Opinion = opinion.Opinion
                    });

                    gymDbContext.SaveChanges();
                }
            }

            return Ok();
        }

        // POST: GymController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(GymViewModel gym)
        {
            try
            {
                if (string.IsNullOrEmpty(gym.Name) ||
                    string.IsNullOrEmpty(gym.Description) ||
                    string.IsNullOrEmpty(gym.Website) ||
                    string.IsNullOrEmpty(gym.Address))

                {
                    ViewBag.InvalidForm = true;
                    return View();
                }
                else
                {
                    gymDbContext.Add(new Gym()
                    {
                        Address = gym.Address,
                        Description = gym.Description,
                        IsActive = true,
                        Name = gym.Name,
                        Website = gym.Website
                    });
                    gymDbContext.SaveChanges();

                    return Redirect("/");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: GymController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GymController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GymController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GymController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
