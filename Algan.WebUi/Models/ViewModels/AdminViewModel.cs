using System.Collections.Generic;
using Algan.Entity;

namespace Algan.WebUi.Models.ViewModels
{
    public class AdminViewModel
    {
        public List<StreamModel> AStreams {get;set;}
        public List<MissionModel> AMissions {get;set;}
        public List<VisionModel> AVisions {get;set;}
        public List<PersonModel> APersons {get;set;}
        public List<SponsorModel> ASponsors {get;set;}
        public List<ProjectModel> AProjects {get;set;}
        public List<PhotoModel> APhotos {get;set;}
        public List<ContactModel> AContacts {get;set;}
        public List<FooterModel> AFooters {get;set;} 
        public List<AboutUsModel> AAboutUsses {get;set;} 

    }
}