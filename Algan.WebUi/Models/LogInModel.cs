using System.ComponentModel.DataAnnotations;

namespace Algan.WebUi.Models
{
    public class LogInModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}