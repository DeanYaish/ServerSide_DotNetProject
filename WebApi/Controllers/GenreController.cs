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

    public class GenreController : ApiController
    {

        public List<GenreDTO> Get()
        {
            MusicStoreEntities db = new MusicStoreEntities();
            return db.Genres.Select(x => new GenreDTO()
            {
                Name = x.Name,
                GenreId = x.GenreId,
            }).ToList();
        }

        [Route("api/genre/{name}")]
        public GenreDTO Get(string name)
        {
            MusicStoreEntities db = new MusicStoreEntities();
            Genre gen = db.Genres.Where(x => x.Name == name).SingleOrDefault();

            if (gen != null)
            {
                GenreDTO mygen = new GenreDTO()
                {
                    GenreId = gen.GenreId,
                    Name = gen.Name,
                };
                return mygen;
            }

            return null;
        }
    }
}