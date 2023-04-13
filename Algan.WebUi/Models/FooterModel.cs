using System.ComponentModel.DataAnnotations;

namespace Algan.WebUi.Models
{
    public class FooterModel
    {
        public int FooterID { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        public string InstagramLink { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        public string LinkedinLink { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        public string TwitterLink { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        public string YoutubeLink { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        public string Mail { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        public string Adress { get; set; } 

        [Required(ErrorMessage ="Boş Girilemez")]
        public string LogoUrl { get; set; }
        
        [Required(ErrorMessage ="Boş Girilemez")]
        public string CompanyName { get; set; } 
    }
}