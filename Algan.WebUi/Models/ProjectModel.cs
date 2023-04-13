using System.ComponentModel.DataAnnotations;

namespace Algan.WebUi.Models
{
    public class ProjectModel
    {
        public int ProjectID { get; set; }

        [Required(ErrorMessage ="Boş Girilemez")]
        public string ProjectName { get; set; }
        public string ProjectPhoto { get; set; }
        
        [Required(ErrorMessage ="Boş Girilemez")]
        public string ProjectDescription { get; set; }
        public string ProjectYoutubeUrl { get; set; }
    }
}