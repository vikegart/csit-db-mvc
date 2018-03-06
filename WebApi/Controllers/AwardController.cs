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
    public class AwardController : ApiController
    {
        [Route("awards/")]
        public IHttpActionResult Get()
        {
            return Json(ProviderLogic.AwardLogic.GetAll());
        }
        [Route("award/{id}")]
        public IHttpActionResult Get(int id)
        {
            var award = ProviderLogic.AwardLogic.GetByID(id);
            if (award == null)
            {
                return NotFound();
            }
            return Json(award);
        }

        [Route(@"awards/{letterName}")]
        [ActionName("Get")]
        public IHttpActionResult GetByletterName(char letterName)
        {
            return Json(ProviderLogic.AwardLogic.GetByLetterName(letterName.ToString()));
        }

        [Route("award/{name:regex(^[A-Za-z_]{2,})}")]
        public IHttpActionResult Get(string name)
        {
            var award = ProviderLogic.AwardLogic.GetByName(name);
            if (award == null)
            {
                return NotFound();
            }
            return Json(award);
        }
        [Route("create-award")]
        public IHttpActionResult Post([FromBody]Award award)
        {
            if (award == null)
            {
                return BadRequest("award null");
            }
            if (ModelState.IsValid)
            {
                int newId = ProviderLogic.AwardLogic.Create(award);
                return Created($"/awardsApi/{newId}", award);
            }
            return BadRequest("New award not valid");
        }
        [Route("award/{id}/edit")]
        public IHttpActionResult Put(int id, [FromBody]Award updateaward)
        {
            var award = ProviderLogic.AwardLogic.GetByID(id);
            if (award == null)
            {
                return NotFound();
            }
            updateaward.ID = id;
            if (ModelState.IsValid)
            {
                ProviderLogic.AwardLogic.Update(updateaward);
                return Ok();
            }
            return BadRequest("update award not valid");
        }
        [Route("award/{id}/delete")]
        public IHttpActionResult Delete(int id)
        {
            var award = ProviderLogic.AwardLogic.GetByID(id);
            if (award == null)
            {
                return NotFound();
            }
            ProviderLogic.AwardLogic.Delete(id);
            return Ok();
        }
        [Route(@"awards/{letterName:regex(^[A-Za-z_]{1})}")]
        [ActionName("Get")]
        public IHttpActionResult GetByFiler(string letterName)
        {
            return Json(ProviderLogic.AwardLogic.GetByLetterName(letterName));
        }
    }
}
