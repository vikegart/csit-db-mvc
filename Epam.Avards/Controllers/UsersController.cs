using AutoMapper;
using Entities;
using Epam.Awards.Models;
using Epam.Awards.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.Awards.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            List<InfoUserModel> users = Mapper.Map<IEnumerable<InfoUserModel>>(ProviderLogic.UserLogic.GetAll()).ToList();
            foreach (var user in users)
            {
                user.ListAwars = ProviderLogic.AwardLogic.GetByIdUser(user.ID).ToList();
            }
            return View(users);
        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(NewUserModel newUser, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                User user = Mapper.Map<User>(newUser);
                int newId = ProviderLogic.UserLogic.Create(user);
                if (image != null)
                {
                    Image newImage = new Image();
                    newImage.Type = image.ContentType;
                    newImage.Name = image.FileName;
                    newImage.Byte = new byte[image.ContentLength];
                    image.InputStream.Read(newImage.Byte, 0, image.ContentLength);
                    newImage.Id_Owner = newId;
                    ProviderLogic.UserLogic.AddImage(newImage);
                }
                return RedirectToAction("InfoUser", "Users", new { id = newId });
            }
            return View();
        }
        public ActionResult InfoUser(int id)
        {
            InfoUserModel user = Mapper.Map<InfoUserModel>(ProviderLogic.UserLogic.GetById(id));
            if (user != null)
            {
                user.ListAwars = ProviderLogic.AwardLogic.GetByIdUser(id).ToList();
            }
            return View(user);
        }
        public ActionResult InfoUserByName(string name)
        {
            InfoUserModel user = Mapper.Map<InfoUserModel>(ProviderLogic.UserLogic.GetByName(name));
            if (user != null)
            {
                user.ListAwars = ProviderLogic.AwardLogic.GetByIdUser(user.ID).ToList();
            }
            return View("InfoUser", user);
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            return View(Mapper.Map<EditUserModel>(ProviderLogic.UserLogic.GetById(id)));
        }
        [HttpPost]
        public ActionResult EditUser(EditUserModel updateUser, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                User user = Mapper.Map<User>(updateUser);
                if (image != null)
                {
                    Image newImage = new Image();
                    newImage.Type = image.ContentType;
                    newImage.Name = image.FileName;
                    newImage.Byte = new byte[image.ContentLength];
                    image.InputStream.Read(newImage.Byte, 0, image.ContentLength);
                    ProviderLogic.UserLogic.UpdateImage(user.ID, newImage);
                }
                ProviderLogic.UserLogic.Update(user);
                return RedirectToAction("InfoUser", "Users", new { id = user.ID });
            }
            return View(updateUser);
        }
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            return View(Mapper.Map<InfoUserModel>(ProviderLogic.UserLogic.GetById(id)));
        }
        [HttpPost]
        public ActionResult DeleteUser(User user)
        {
            ProviderLogic.UserLogic.Delete(user.ID);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteImage(int id)
        {
            ProviderLogic.UserLogic.DeleteImage(id);
            return RedirectToAction("InfoUser", "Users", new { id = id });
        }

        public ActionResult GetUsersByLetterName(string searchUserByLetterName)
        {
            IEnumerable<InfoUserModel> users = Mapper.Map<IEnumerable<InfoUserModel>>(ProviderLogic.UserLogic.GetByLetterName(searchUserByLetterName));
            if (users != null)
            {
                foreach (var user in users)
                {
                    user.ListAwars = ProviderLogic.AwardLogic.GetByIdUser(user.ID).ToList();
                }
                return View("Index", users);
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetUsersByPartName(string searchUserByPartName)
        {
            IEnumerable<InfoUserModel> users = Mapper.Map<IEnumerable<InfoUserModel>>(ProviderLogic.UserLogic.GetByPartName(searchUserByPartName));
            if (users != null)
            {
                foreach (var user in users)
                {
                    user.ListAwars = ProviderLogic.AwardLogic.GetByIdUser(user.ID).ToList();
                }
                return View("Index", users);
            }
            return RedirectToAction("Index");
        }
        public ActionResult SearchByName(string name)
        {
            IEnumerable<InfoUserModel> users;
            InfoUserModel user = Mapper.Map<InfoUserModel>(ProviderLogic.UserLogic.GetByName(name));
            if (user != null)
            {
                ViewBag.Awards = ProviderLogic.AwardLogic.GetByIdUser(user.ID);
                return View("InfoUser", user);
            }
            if (name.Count() == 1)
            {
                users = Mapper.Map<IEnumerable<InfoUserModel>>(ProviderLogic.UserLogic.GetByLetterName(name));
                if (users != null)
                {
                    return View("Index", users);
                }
            }
            users = Mapper.Map<IEnumerable<InfoUserModel>>(ProviderLogic.UserLogic.GetByPartName(name));
            if (users != null)
            {
                return View("Index", users);
            }
            return RedirectToAction("Index");
        }
    }
}