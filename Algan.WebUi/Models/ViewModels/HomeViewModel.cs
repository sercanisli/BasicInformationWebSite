using System.Collections.Generic;
using Algan.Entity;

namespace Algan.WebUi.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<StreamModel> Streams {get;set;}
        public List<MissionModel> Missions {get;set;}
        public List<VisionModel> Visions {get;set;}
        public List<PersonModel> Persons {get;set;}
        public List<SponsorModel> Sponsors {get;set;}
        public List<PhotoModel> Photos {get;set;}
        public List<FooterModel> Footers {get;set;} 





    }
}