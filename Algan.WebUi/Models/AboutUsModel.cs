using System.ComponentModel.DataAnnotations;

namespace Algan.WebUi.Models
{
    public class AboutUsModel
    {
        public int AboutUsID { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        public string AboutUsTitle { get; set; }
        
        [Required(ErrorMessage ="Boş Girilemez")]
        public string AboutUsText { get; set; }
    }
}