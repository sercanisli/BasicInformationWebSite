using System.ComponentModel.DataAnnotations;

namespace Algan.WebUi.Models
{
    public class VisionModel
    {
        public int VisionID { get; set; }
        [Required(ErrorMessage ="Boş Girilemez")]
        public string VisionText { get; set; }
    }
}