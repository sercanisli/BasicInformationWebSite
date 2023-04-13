using System.ComponentModel.DataAnnotations;

namespace Algan.WebUi.Models
{
    public class StreamModel
    {
        public int StreamID { get; set; }
        [Required(ErrorMessage ="Boş Girilemez")]
        public string StreamUrl { get; set; }
    }
}