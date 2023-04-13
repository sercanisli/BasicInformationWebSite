using System.ComponentModel.DataAnnotations;

namespace Algan.WebUi.Models
{
    public class SponsorModel
    {
        public int SponsorID { get; set; }
        [Required(ErrorMessage ="Boş Girilemez")]
        public string SponsorName { get; set; }
        [Required(ErrorMessage ="Boş Girilemez")]
        public string SponsorTitle { get; set; }
        public string SponsorLogo { get; set; }
        public string SponsorUrl { get; set; }
    }
}