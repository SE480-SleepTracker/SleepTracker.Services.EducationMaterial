using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SleepTracker.Services.Education.Models;

namespace SleepTracker.Services.Education.Controllers
{
    public class EducationArticleController : ApiController
    {
        private EducationMaterialContext db = new EducationMaterialContext();

        // GET api/EducationArticle
        public IQueryable<EducationArticle> GetEducationArticles()
        {
            return db.EducationArticles;
        }

        // GET api/EducationArticle/5
        [ResponseType(typeof(EducationArticle))]
        public IHttpActionResult GetEducationArticle(long id)
        {
            EducationArticle educationarticle = db.EducationArticles.Find(id);
            if (educationarticle == null)
            {
                return NotFound();
            }

            return Ok(educationarticle);
        }

        // PUT api/EducationArticle/5
        public IHttpActionResult PutEducationArticle(long id, EducationArticle educationarticle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != educationarticle.Id)
            {
                return BadRequest();
            }

            db.Entry(educationarticle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationArticleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/EducationArticle
        [ResponseType(typeof(EducationArticle))]
        public IHttpActionResult PostEducationArticle(EducationArticle educationarticle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EducationArticles.Add(educationarticle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = educationarticle.Id }, educationarticle);
        }

        // DELETE api/EducationArticle/5
        [ResponseType(typeof(EducationArticle))]
        public IHttpActionResult DeleteEducationArticle(long id)
        {
            EducationArticle educationarticle = db.EducationArticles.Find(id);
            if (educationarticle == null)
            {
                return NotFound();
            }

            db.EducationArticles.Remove(educationarticle);
            db.SaveChanges();

            return Ok(educationarticle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EducationArticleExists(long id)
        {
            return db.EducationArticles.Count(e => e.Id == id) > 0;
        }
    }
}