using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    [MetadataType(typeof(AlbumMetaData))]
    public partial class Album
    {

    }

    public class AlbumMetaData
    {
        [Range(1, Int32.MaxValue, ErrorMessage = "ArtistId ID Must be Greater Then Zero")]
        public int ArtistId;
        [Required(AllowEmptyStrings = false)]
        [MinLength(3,ErrorMessage = "Album Title Must Be 3 chars and above")]
        public string Title;

    }
}