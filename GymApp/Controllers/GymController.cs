using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Controllers
{
    public class GymController : Controller
    {
        // GET: GymController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GymController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GymController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GymController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
