using DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.DTO;

namespace WebApi.Controllers
{

    public class PlaylistsController : ApiController
    {
        
        // GET api/<controller>
        public List<PlaylistsDTO> Get()
        {
            MusicStoreEntities db = new MusicStoreEntities();
            return db.Playlists.OrderBy(o => o.PlaylistId).Select(a => new PlaylistsDTO()
            {
                PlaylistId = a.PlaylistId,
                Name = a.Name
            }).ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}