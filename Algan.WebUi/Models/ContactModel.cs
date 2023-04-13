using System.ComponentModel.DataAnnotations;

namespace Algan.WebUi.Models
{
    public class ContactModel
    {
        public int ContactID { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="Boş Girilemez")]
        public string Topic { get; set; }
        
        [Required(ErrorMessage ="Boş Girilemez")]
        public string Message { get; set; }
    }
}