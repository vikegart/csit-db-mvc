using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.Avards.Controllers
{
    public class AvardController : Controller
    {
        // GET: Avard
        public ActionResult Index()
        {
            return View();
        }

        // GET: Avard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Avard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Avard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Avard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Avard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Avard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Avard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
