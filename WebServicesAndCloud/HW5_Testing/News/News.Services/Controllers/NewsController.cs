﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using News.Data;
using News.Services.Models;

namespace News.Services.Controllers
{
    public class NewsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/NewsItems
        public IQueryable<NewsItem> GetNewsItems()
        {
            return db.NewsItems;
        }

        // GET: api/NewsItems/5
        [ResponseType(typeof(NewsItem))]
        public IHttpActionResult GetNewsItem(int id)
        {
            NewsItem newsItem = db.NewsItems.Find(id);
            if (newsItem == null)
            {
                return NotFound();
            }

            return Ok(newsItem);
        }

        // PUT: api/NewsItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNewsItem(int id, NewsItem newsItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsItem.Id)
            {
                return BadRequest();
            }

            db.Entry(newsItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsItemExists(id))
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

        // POST: api/NewsItems
        [ResponseType(typeof(NewsItem))]
        public IHttpActionResult PostNewsItem(NewsItem newsItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NewsItems.Add(newsItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newsItem.Id }, newsItem);
        }

        // DELETE: api/NewsItems/5
        [ResponseType(typeof(NewsItem))]
        public IHttpActionResult DeleteNewsItem(int id)
        {
            NewsItem newsItem = db.NewsItems.Find(id);
            if (newsItem == null)
            {
                return NotFound();
            }

            db.NewsItems.Remove(newsItem);
            db.SaveChanges();

            return Ok(newsItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewsItemExists(int id)
        {
            return db.NewsItems.Count(e => e.Id == id) > 0;
        }
    }
}