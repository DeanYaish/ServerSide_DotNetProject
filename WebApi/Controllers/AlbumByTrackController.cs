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

    public class AlbumByTrackController : ApiController
    {
        // GET api/<controller>
        [Route("api/albumbytrack/{Id}")]
        public AlbumDTO Get(int Id)
        {
            MusicStoreEntities db = new MusicStoreEntities();
            var album = db.Albums.SingleOrDefault(x => x.AlbumId == Id);
            if (album != null) 
            {
                AlbumDTO myalbum = new AlbumDTO()
                {
                    AlbumId = album.AlbumId,
                    Title = album.Title,
                    ArtistId = album.ArtistId

                };
                return myalbum;
            }
            return null;
        }
    }
}