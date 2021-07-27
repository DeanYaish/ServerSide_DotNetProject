using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTO
{
    public class NewTrackDTO
    {
        public string Name;
        public Nullable<int> AlbumId;
        public int MediaTypeId;
        public Nullable<int> GenreId;
        public string Composer;
        public int Milliseconds;
        public Nullable<int> Bytes;
        public decimal UnitPrice;
    }
}