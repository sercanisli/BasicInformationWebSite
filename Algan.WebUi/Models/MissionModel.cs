using System.ComponentModel.DataAnnotations;

namespace Algan.WebUi.Models
{
    public class MissionModel
    {
        public int MissionID { get; set; }
        
        [Required(ErrorMessage ="Boş Girilemez")]
        public string MissionText { get; set; }
    }
}