using System.ComponentModel.DataAnnotations;

namespace Algan.WebUi.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Boş Girilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        [DataType(DataType.EmailAddress)] 
        public string Email { get; set; }


    }
}