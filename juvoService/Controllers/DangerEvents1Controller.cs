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
using juvoService.Models;
using Microsoft.Azure.Mobile.Server.Config;
using System.Diagnostics;
using Newtonsoft.Json;

namespace juvoService.Controllers
{
    [MobileAppController]
    [Authorize]
    public class DangerEvents1Controller : ApiController
    {
        //DbContext db = new DbContext();
        private TEST db = new TEST();
        //private juvoContext db = new juvoContext();

        // GET: api/DangerEvents1
        public IQueryable<DangerEvents> GetDangerEvents()
        {
            
            return db.DangerEvents;            
        }

        // GET: api/DangerEvents1/5
        [ResponseType(typeof(List<DangerEvents>))]
        public IHttpActionResult GetDangerEvents(string id)
        {
            List<Users> users = new List<Users>();
            List<int> devices = new List<int>();
            List<DangerEvents> events = new List<DangerEvents>();
            int temp = int.Parse(id);

            users = db.Users.Where(u => u.ID == temp).ToList();
            Trace.WriteLine("Prvi tag: " + users.ToString());   
            // foreach(int name in users)
            // {
            //     Debug.WriteLine(name);
            //     Trace.WriteLine("Prvi tag: " + name);
            //     devices = db.Devices.Where(d => d.UserId == name).Select(d => d.DevicesID).ToList();
            // }
            // foreach(int device in devices)
            // {
            //     Trace.WriteLine("Drugi tag: " + device);
            //     events = db.DangerEvents.Where(e => e.DeviceId == device).ToList();
            //     
            // }
            // Trace.Write(events);
            //
            // Trace.WriteLine("Treci tag: " + events);
            // if (events == null)
            //  {
            //      return NotFound();
            //  }

            return Ok(users);
        }

        // PUT: api/DangerEvents1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDangerEvents(int id, DangerEvents dangerEvents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dangerEvents.ID)
            {
                return BadRequest();
            }

            db.Entry(dangerEvents).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DangerEventsExists(id))
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

        [AllowAnonymous]
        // POST: api/DangerEvents1
        [ResponseType(typeof(DangerEvents))]
        public IHttpActionResult PostDangerEvents(DangerEvents dangerEvents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DangerEvents.Add(dangerEvents);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DangerEventsExists(dangerEvents.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dangerEvents.ID }, dangerEvents);
        }

        // DELETE: api/DangerEvents1/5
        [ResponseType(typeof(DangerEvents))]
        public IHttpActionResult DeleteDangerEvents(string id)
        {
            DangerEvents dangerEvents = db.DangerEvents.Find(id);
            if (dangerEvents == null)
            {
                return NotFound();
            }

            db.DangerEvents.Remove(dangerEvents);
            db.SaveChanges();

            return Ok(dangerEvents);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DangerEventsExists(int id)
        {
            return db.DangerEvents.Count(e => e.ID == id) > 0;
        }
    }
}