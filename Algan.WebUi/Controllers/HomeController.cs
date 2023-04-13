using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Algan.Business.Abstract;
using Algan.Data.Abstract;
using Algan.WebUi.Models.ViewModels;
using Algan.Entity;
using System.Linq;
using System.Diagnostics;
using Algan.WebUi.Models;
using Algan.Business;
using Microsoft.Extensions.Configuration;

namespace Algan.WebUi.Controllers
{
    public class HomeController : Controller
    {
        public IStreamService _streamService;
        public IMissionService _missionService;
        public IVisionService _visionService;
        public IPersonService _personService;
        public ISponsorService _sponsorService;
        public IPhotoService _photoService;
        public IFooterService _footerService;
        public IAboutUsService _aboutUsService;
        public IContactService _contactService;
        public IProjectService _projectService;

        
 

        public HomeController (IStreamService streamService, IMissionService missionService, IVisionService visionService, IPersonService personService, ISponsorService sponsorService, IPhotoService photoService, IFooterService footerService, IAboutUsService aboutUsService, IContactService contactService, IProjectService projectService)
        {
            this._streamService=streamService;
            this._missionService=missionService;
            this._visionService=visionService;
            this._personService=personService;
            this._sponsorService=sponsorService;
            this._photoService=photoService; 
            this._footerService=footerService;
            this._aboutUsService=aboutUsService;
            this._contactService=contactService;
            this._projectService=projectService;
        }
        public IActionResult Index ()
        {
            var homeViewModel = new HomeViewModel();
            List<Stream> streams = _streamService.GetAll();
            List<Mission> missions = _missionService.GetAll();
            List<Person> persons = _personService.GetAll();
            List<Sponsor> sponsors = _sponsorService.GetAll(); 
            List<Vision> visions =_visionService.GetAll();
            List<Photo> photos = _photoService.GetAll();
            List<Footer> footers = _footerService.GetAll();

            homeViewModel.Streams = streams.Select(x=> new StreamModel
            {
                StreamID = x.StreamID,
                StreamUrl= x.StreamUrl
            }).ToList();

            homeViewModel.Missions = missions.Select(x=> new MissionModel
            {
                MissionID = x.MissionID,
                MissionText= x.MissionText
            }).ToList();

            homeViewModel.Visions = visions.Select(x=> new VisionModel
            {
                VisionID=x.VisionID,
                VisionText=x.VisionText
            }).ToList();

            homeViewModel.Persons=persons.Select(x=> new PersonModel
            {
                PersonID=x.PersonID,
                PersonFullName=x.PersonFullName,
                PersonUniversity=x.PersonUniversity,
                PersonUniversityDepartmant=x.PersonUniversityDepartmant,
                PersonJob=x.PersonJob,
                PersonPhoto=x.PersonPhoto

             }).ToList();

            homeViewModel.Sponsors=sponsors.Select(x=> new SponsorModel
            {
                SponsorID=x.SponsorID,
                SponsorName=x.SponsorName,
                SponsorTitle=x.SponsorTitle,
                SponsorUrl=x.SponsorUrl,
                SponsorLogo=x.SponsorLogo
            }).ToList();

            homeViewModel.Photos=photos.Select(x=> new PhotoModel
            {
                PhotoID=x.PhotoID,
                PhotoImageUrl=x.PhotoImageUrl
            }).ToList();
            homeViewModel.Footers=footers.Select(x=> new FooterModel
            {
                FooterID=x.FooterID,
                InstagramLink=x.InstagramLink,
                LinkedinLink=x.LinkedinLink,
                TwitterLink=x.TwitterLink,
                YoutubeLink=x.YoutubeLink,
                Mail=x.Mail,
                Adress=x.Adress,
                LogoUrl=x.LogoUrl,
                CompanyName=x.CompanyName
            }).ToList();

           return View(homeViewModel);
        }
        public IActionResult AboutUs ()
        {
            var aboutUsViewModel = new AboutUsViewModel ()
            {
                AdminAboutUsses=_aboutUsService.GetAll()
            };
            return View(aboutUsViewModel);
        }
        public IActionResult Project ()
        {
            var projectViewModel = new ProjectViewModel ()
            {
                AdminProjects=_projectService.GetAll()
            };
            return View(projectViewModel);
        }
        public IActionResult ProjectDetail (int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            Project project = _projectService.GetByID((int)id);
            if(project==null)
            {
                return NotFound();
            }
            return View (project);
        }

        [HttpGet]
        public IActionResult Contact()
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult Contact(ContactModel contactModel)
        {
            if(ModelState.IsValid)
            {
                var entity = new Contact()
                {
                    FullName = contactModel.FullName,
                    Email=contactModel.Email,
                    Topic=contactModel.Topic,
                    Message=contactModel.Message
                };


                _contactService.Create(entity);
                return RedirectToAction("Contact"); 
            }
            return View (contactModel);
        }

    }
}