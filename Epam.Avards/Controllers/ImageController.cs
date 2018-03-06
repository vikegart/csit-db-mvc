using Entities;
using Epam.Awards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.Awards.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public FileContentResult GetImageByUser(int id, int newWidth, int maxHeight, bool reduceOnly)
        {
            Image image = ProviderLogic.UserLogic.GetImageByUser(id, newWidth, maxHeight, reduceOnly);
            if (image != null)
            {
                return File(image.Byte, image.Type);
            }
            return null;
        }

        public FileContentResult GetImageByAward(int id, int newWidth, int maxHeight, bool reduceOnly)
        {
            Image image = ProviderLogic.AwardLogic.GetImageByAward(id, newWidth, maxHeight, reduceOnly);
            if (image != null)
            {
                return File(image.Byte, image.Type);
            }
            return null;
        }
    }
}