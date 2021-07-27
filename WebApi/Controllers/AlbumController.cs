using DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.DTO;

namespace WebApi.Controllers
{
    public class AlbumController : ApiController
    {
        
        [HttpGet]
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

        // POST api/<controller>
        [HttpPost]
        [Route("api/album/")]
        public HttpResponseMessage Post(NewAlbumDTO album)
        {
            MusicStoreEntities db = new MusicStoreEntities();

            Album album1;

            Artist checkartist = db.Artists.SingleOrDefault(x => x.Name == album.ArtistName);
            if (checkartist == null)
            {
                Artist newartist = new Artist
                {
                    ArtistId = db.Artists.Count() + 1,
                    Name = album.ArtistName
                };

                album1 = new Album
                {
                    AlbumId = db.Albums.Count() + 1,
                    ArtistId = newartist.ArtistId,
                    Title = album.Title
                };

            }
            else
            {
                Album checkAlbum = db.Albums.SingleOrDefault(x => (x.Title == album.Title) && (x.ArtistId == checkartist.ArtistId));
                if (checkAlbum != null) { return Request.CreateResponse(HttpStatusCode.BadRequest, "This Album is already in the store database"); ; }

                album1 = new Album
                {
                    AlbumId = db.Albums.Count() + 1,
                    ArtistId = checkartist.ArtistId,
                    Title = album.Title
                };
            }




            db.Albums.Add(album1);

            return Request.CreateResponse(HttpStatusCode.OK, "Album added successfully");
        }


    
    }
}