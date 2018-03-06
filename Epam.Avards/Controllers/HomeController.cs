using Epam.Awards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.Awards.Controllers
{
    public class HomeController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
        public FileResult Download()
        {
            byte[] mas = ProviderLogic.UserLogic.Download();
            string file_type = "application/txt";
            string file_name = "InfoUsers.txt";
            return File(mas, file_type, file_name);
        }
    }
}