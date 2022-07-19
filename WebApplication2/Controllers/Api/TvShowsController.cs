using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Api
{
    public class TvShowsController : ApiController
    {
        private ApplicationDbContext _context;

        public TvShowsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<TvShow> GetTvShow(string query = null)
        {
            var TvShowQuery = _context.TvShow;
                

            

            return TvShowQuery.ToList();
        }

        public IHttpActionResult GetTvShow(int id)
        {
            var tvshow = _context.TvShow.SingleOrDefault(c => c.Show_Id == id);

            if (tvshow == null)
                return NotFound();

            return Ok();
        }

        // GET api/<controller>
        [HttpPost]
        public TvShow CreateTvShow(TvShow tvshow)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.TvShow.Add(tvshow);
            _context.SaveChanges();
            return tvshow;
        }
        
        //Update
        [HttpPut]
        public IHttpActionResult UpdateTvShow(int id, TvShow tvshow)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var TvShowInDb = _context.TvShow.SingleOrDefault(c => c.Show_Id == id);
            if (TvShowInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            TvShowInDb.Name = tvshow.Name;
            TvShowInDb.Duration = tvshow.Duration;
            _context.SaveChanges();
            return Ok();
        }

        

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult DeleteTvShow(int id)
        {
            var TvShowInDb = _context.TvShow.SingleOrDefault(c => c.Show_Id == id);
            if (TvShowInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.TvShow.Remove(TvShowInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}