using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTO
{
    public class TracksDTO
    {
        public int TrackId;
        public string Name;
        public int? AlbumId;
        public int? GenreId;
        public decimal UnitPrice;
        public string GenreName;
        public List<InvoiceLineDTO> invoice;
    }
}