using AutoMapper;
using Entities;
using Epam.Awards.Models;
using Epam.Awards.ViewModels.Award;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.Avards.Controllers
{
    public class AwardsController : Controller
    {
        // GET: Award
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<InfoAwardModel>>(ProviderLogic.AwardLogic.GetAll()));
        }
        [HttpGet]
        public ActionResult CreateAward()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAward(NewAwardModel newAward)
        {
            if (ModelState.IsValid)
            {
                Award award = Mapper.Map<Award>(newAward);
                int newId = ProviderLogic.AwardLogic.Create(award);
                Image newImage = new Image();
                newImage.Type = newAward.image.ContentType;
                newImage.Name = newAward.image.FileName;
                newImage.Byte = new byte[newAward.image.ContentLength];
                newAward.image.InputStream.Read(newImage.Byte, 0, newAward.image.ContentLength);
                newImage.Id_Owner = newId;
                ProviderLogic.AwardLogic.AddImage(newImage);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult InfoAward(int id)
        {
            return View(Mapper.Map<InfoAwardModel>(ProviderLogic.AwardLogic.GetByID(id)));
        }

        public ActionResult AddUserToAward(int id)
        {
            ViewBag.User = ProviderLogic.UserLogic.GetById(id);
            return View(Mapper.Map<IEnumerable<InfoAwardModel>>(ProviderLogic.AwardLogic.GetFreeAwards(id)));
        }
        public ActionResult SetUserToAward(int idAward, int idUser)
        {
            ProviderLogic.AwardLogic.SetAwardToUser(idUser, idAward);
            return RedirectToAction("InfoUser", "Users", new { id = idUser });
        }
        [HttpGet]
        public ActionResult EditAward(int id)
        {
            return View(Mapper.Map<InfoAwardModel>(ProviderLogic.AwardLogic.GetByID(id)));
        }
        [HttpPost]
        public ActionResult EditAward(InfoAwardModel updateAward, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                Award award = Mapper.Map<Award>(updateAward);
                if (image != null)
                {
                    Image newImage = new Image();
                    newImage.Type = image.ContentType;
                    newImage.Name = image.FileName;
                    newImage.Byte = new byte[image.ContentLength];
                    image.InputStream.Read(newImage.Byte, 0, image.ContentLength);
                    ProviderLogic.AwardLogic.UpdateImage(award.ID, newImage);
                }
                ProviderLogic.AwardLogic.Update(award);
                return RedirectToAction("InfoAward", "Awards", new { id = updateAward.ID });
            }
            return View(updateAward);
        }
        [HttpGet]
        public ActionResult DeleteAward(int id)
        {
            return View(Mapper.Map<InfoAwardModel>(ProviderLogic.AwardLogic.GetByID(id)));
        }
        [HttpPost]
        public ActionResult DeleteAward(Award award)
        {
            ProviderLogic.AwardLogic.Delete(award.ID);
            return RedirectToAction("Index");
        }
        public ActionResult CancelAwardToUser(int idUser, int idAward)
        {
            ProviderLogic.AwardLogic.CancelAwardToUser(idUser, idAward);
            return RedirectToAction("InfoUser", "Users", new { id = idUser });
        }

        public ActionResult GetByName(string name)
        {
            InfoAwardModel award = Mapper.Map<InfoAwardModel>(ProviderLogic.AwardLogic.GetByName(name));
            if (award != null)
            {
                ViewBag.Awards = ProviderLogic.AwardLogic.GetByIdUser(award.ID);
            }
            return View("InfoAward", award);
        }
        public ActionResult GetByLetterName(string searchAwardByLetterName)
        {
            IEnumerable<InfoAwardModel> awards = Mapper.Map<IEnumerable<InfoAwardModel>>(ProviderLogic.AwardLogic.GetByLetterName(searchAwardByLetterName));
            if (awards != null)
            {
                return View("Index", awards);
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetByPartName(string searchAwardByPartName)
        {
            IEnumerable<InfoAwardModel> awards = Mapper.Map<IEnumerable<InfoAwardModel>>(ProviderLogic.AwardLogic.GetByPartName(searchAwardByPartName));
            if (awards != null)
            {
                return View("Index", awards);
            }
            return RedirectToAction("Index");
        }
        public ActionResult SearchByName(string name)
        {
            IEnumerable<InfoAwardModel> awards;
            InfoAwardModel award = Mapper.Map<InfoAwardModel>(ProviderLogic.AwardLogic.GetByName(name));
            if (award != null)
            {
                return View("InfoAward", award);
            }
            if (name.Count() == 1)
            {
                awards = Mapper.Map<IEnumerable<InfoAwardModel>>(ProviderLogic.AwardLogic.GetByLetterName(name));
                if (awards != null)
                {
                    return View("Index", awards);
                }
            }
            awards = Mapper.Map<IEnumerable<InfoAwardModel>>(ProviderLogic.AwardLogic.GetByPartName(name));
            if (awards != null)
            {
                return View("Index", awards);
            }
            return RedirectToAction("Index");

        }
    }
}
