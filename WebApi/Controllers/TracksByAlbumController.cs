using DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.DTO;

namespace WebApi.Controllers
{
    public class TracksByAlbumController : ApiController
    {
        // GET api/<controller>
        [Route("api/tracksbyalbum/{Id}")]
        public List<TracksDTO> Get(int Id)
        {
            MusicStoreEntities db = new MusicStoreEntities();
            return db.Tracks.Where(x => x.AlbumId == Id).Select(s => new TracksDTO()
            {
                TrackId = s.TrackId,
                AlbumId = s.AlbumId,
                Name = s.Name,
                GenreId = s.GenreId,
                UnitPrice = s.UnitPrice,
                invoice = db.InvoiceLines.Where(u => u.TrackId == s.TrackId).Select(p => new InvoiceLineDTO()
                {
                    UnitPrice = p.UnitPrice,
                    Quantity = p.Quantity,

                }).ToList()
            }).ToList();
        }

        [HttpPost]
        [Route("api/tracksbyalbum/{Title}/{Artist}")]
        public HttpResponseMessage Post([FromBody]List<NewTrackDTO> tracks, string Title, string Artist)
        {
            MusicStoreEntities db = new MusicStoreEntities();


            Album album1;

            Artist checkartist = db.Artists.SingleOrDefault(x => x.Name == Artist);
            if (checkartist == null)
            {
                Artist newartist = new Artist
                {
                    ArtistId = db.Artists.Count() + 1,
                    Name = Artist
                };

                album1 = new Album
                {
                    AlbumId = db.Albums.Count() + 1,
                    ArtistId = newartist.ArtistId,
                    Title = Title
                };

            }
            else
            {
                Album checkAlbum = db.Albums.SingleOrDefault(x => (x.Title == Title) && (x.ArtistId == checkartist.ArtistId));
                if (checkAlbum != null) { return Request.CreateResponse(HttpStatusCode.BadRequest, "This Album is already in the store database"); ; }

                album1 = new Album
                {
                    AlbumId = db.Albums.Count() + 1,
                    ArtistId = checkartist.ArtistId,
                    Title = Title
                };
            }




            db.Albums.Add(album1);



            for (int i = 0; i < tracks.Count; i++)
            {

                Track track = new Track
                {
                    TrackId = Convert.ToInt32(db.Tracks.Count() + 1),
                    Name = tracks[i].Name,
                    AlbumId = album1.AlbumId,
                    MediaTypeId = tracks[i].MediaTypeId,
                    GenreId = tracks[i].GenreId,
                    Composer = tracks[i].Composer,
                    Milliseconds = Convert.ToInt32(tracks[i].Milliseconds),
                    Bytes = Convert.ToInt32(tracks[i].Bytes),
                    UnitPrice = Convert.ToDecimal(tracks[i].UnitPrice),
  
                };

                db.Tracks.Add(track);
            }


            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException err)
            {
                string errors = "";
                foreach (DbEntityValidationResult vr in err.EntityValidationErrors)
                {
                    foreach (DbValidationError er in vr.ValidationErrors)
                    {
                        errors += $"PropertyName - {er.PropertyName }, Error {er.ErrorMessage} <br/>";
                    }
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
            catch (DbUpdateConcurrencyException err)
            {
                var ctx = ((IObjectContextAdapter)db).ObjectContext;
                foreach (var et in err.Entries)
                {
                    //client win
                    ctx.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, et.Entity);

                }
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Values are Updated");
            }
            catch (Exception err)
            {
                return Request.CreateResponse(HttpStatusCode.NotImplemented, err);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Songs added successfully");
        }


    }

}