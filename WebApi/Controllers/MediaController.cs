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

    public class MediaController : ApiController
    {
        // GET api/<controller>
        public List<MediaDTO> Get()
        {
            MusicStoreEntities db = new MusicStoreEntities();
            return db.MediaTypes.Select(x => new MediaDTO()
            {
                Name = x.Name,
                MediaTypeId = x.MediaTypeId,
            }).ToList();
        }
    }
}