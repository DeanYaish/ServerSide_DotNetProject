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
    
    public class AlbumByArtistController : ApiController
    {
        // GET api/<controller>
        public List<AlbumDTO> Get()
        {
            MusicStoreEntities db = new MusicStoreEntities();
            return db.Albums.OrderBy(o => o.AlbumId).Select(a => new AlbumDTO()
            {
                Title = a.Title,
                AlbumId = a.AlbumId,
                ArtistId = a.ArtistId,
            }).ToList();
        }



        // GET api/<controller>/id
        [Route("api/albumbyartist/{Id}")]
        public List<AlbumDTO> Get(int Id)
        {
            MusicStoreEntities db = new MusicStoreEntities();
            return db.Albums.OrderBy(o => o.AlbumId).Where(x => x.ArtistId == Id).Select(a => new AlbumDTO() {
                Title = a.Title,
                AlbumId = a.AlbumId,
                ArtistId = a.ArtistId,
            }).ToList();
        }
    }
}