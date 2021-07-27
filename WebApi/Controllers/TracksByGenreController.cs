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
    public class TracksByGenreController : ApiController
    {
        // GET api/<controller>
        [Route("api/tracksbygenre/{Id}")]
        public List<TracksDTO> Get(int Id)
        {
            MusicStoreEntities db = new MusicStoreEntities();
            return db.Tracks.OrderBy(o => o.AlbumId).Where(x => x.GenreId == Id).Select(a => new TracksDTO()
            {
                TrackId = a.TrackId,
                AlbumId = a.AlbumId,
                Name = a.Name,
                GenreId = a.GenreId,
                invoice = db.InvoiceLines.Where(u => u.TrackId == a.TrackId).Select(p => new InvoiceLineDTO()
                {
                    UnitPrice = p.UnitPrice,
                    Quantity = p.Quantity,

                }).ToList()
            }).ToList();
        }
    }
}