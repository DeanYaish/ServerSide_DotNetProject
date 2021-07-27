using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DATA;
using WebApi.DTO;


namespace WebApi.Controllers
{

    public class ArtistController : ApiController
    {

        public List<ArtistDTO> Get()
        {
            MusicStoreEntities db = new MusicStoreEntities();
            return db.Artists.Select(a => new ArtistDTO()
            {
                Name = a.Name,
                ArtistId = a.ArtistId,
            }).ToList();
        }

        // GET api/Artist
        [Route("api/artist/{name}")]
        public ArtistDTO Get(string name)
        {
            MusicStoreEntities db = new MusicStoreEntities();
            Artist a = db.Artists.Where(x => x.Name == name).SingleOrDefault();

            if (a != null)
            {
                ArtistDTO alpha = new ArtistDTO() {
                    ArtistId = a.ArtistId,
                    Name = a.Name,
                };
                return alpha;
            }

            return null;
        }

      
        
    }
}