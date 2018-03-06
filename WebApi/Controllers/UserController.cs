using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        [Route(@"users/{letterName}")]
        [ActionName("Get")]
        public IHttpActionResult GetByletterName(char letterName)
        {
            return Json(ProviderLogic.UserLogic.GetByLetterName(letterName.ToString()));
        }

        [Route(@"users/{partName:regex(^[A-Za-z_]{2,})}")]
        [ActionName("Get")]
        public IHttpActionResult GetBypartName(string partName)
        {
            return Json(ProviderLogic.UserLogic.GetByPartName(partName));
        }
        [Route("users/")]
        public IHttpActionResult Get()
        {
            return Json(ProviderLogic.UserLogic.GetAll());
        }
        [Route("user/{id}")]
        public IHttpActionResult Get(int id)
        {
            var user = ProviderLogic.UserLogic.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }
        [Route("user/{name:regex(^[A-Za-z_]+)}")]
        public IHttpActionResult Get(string name)
        {
            var user = ProviderLogic.UserLogic.GetByName(name);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }
        [Route("create-user")]
        public IHttpActionResult Post([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest("User null");
            }
            if (ModelState.IsValid)
            {
                int newId = ProviderLogic.UserLogic.Create(user);
                return Created($"/UsersApi/{newId}", user);
            }
            return BadRequest("New User not valid");
        }
        [Route("user/{id}/edit")]
        public IHttpActionResult Put(int id, [FromBody]User updateUser)
        {
            var user = ProviderLogic.UserLogic.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            updateUser.ID = id;
            if (ModelState.IsValid)
            {
                ProviderLogic.UserLogic.Update(updateUser);
                return Ok();
            }
            return BadRequest("update User not valid");
        }
        [Route("user/{id}/delete")]
        public IHttpActionResult Delete(int id)
        {
            var user = ProviderLogic.UserLogic.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            ProviderLogic.UserLogic.Delete(id);
            return Ok();
        }
    }
}
