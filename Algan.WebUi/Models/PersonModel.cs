using System.ComponentModel.DataAnnotations;

namespace Algan.WebUi.Models
{
    public class PersonModel
    {
        public int PersonID { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        public string PersonFullName { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        public string PersonUniversity { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        public string PersonUniversityDepartmant { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        public string PersonJob { get; set; }
        public string PersonPhoto { get; set; }
    }
}