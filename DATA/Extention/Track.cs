using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    [MetadataType(typeof(TrackMetaData))]
    public partial class Track
    {

    }

    public class TrackMetaData 
    {
        [Range(1, Int32.MaxValue, ErrorMessage = "Album ID Must be Greater Then Zero")]
        public Nullable<int> AlbumId;

        [Required(AllowEmptyStrings = false)]
        [MinLength(3, ErrorMessage = "Song Title Must Be 3 chars and above")]
        public string Name;

        [Range(1,5,ErrorMessage = "MediaType is Unknown, Please use the AutoComplete values!")]
        public int MediaTypeId;

        [Range(1, 25, ErrorMessage = "GenreId is Unknown, Please use the AutoComplete values!")]
        public Nullable<int> GenreId;

        [Required(AllowEmptyStrings = false)]
        [MinLength(3, ErrorMessage = "Composer Name Must Be 3 chars and above")]
        public string Composer;

        [Range(1, Int32.MaxValue,ErrorMessage = "Song Duration Must be Greater Then Zero")]
        public int Milliseconds;

        [Range(1, Int32.MaxValue, ErrorMessage = "Song Size Must be Greater Then Zero")]
        public Nullable<int> Bytes;

        [Range(0.001,10, ErrorMessage = "Price Must be Between 0.001 to 10")]
        public decimal UnitPrice;

    }
}
