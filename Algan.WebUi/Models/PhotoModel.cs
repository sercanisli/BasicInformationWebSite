using System.ComponentModel.DataAnnotations;

namespace Algan.WebUi.Models
{
    public class PhotoModel
    {
        public int PhotoID { get; set; }
        [Required(ErrorMessage ="Boş Girilemez")]
        public string PhotoImageUrl { get; set; }
    }
}