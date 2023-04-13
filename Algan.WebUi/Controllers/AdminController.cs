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
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization; 



namespace Algan.WebUi.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IStreamService _streamService;
        private IMissionService _missionService;
        private IVisionService _visionService;
        private IPersonService _personService;
        private ISponsorService _sponsorService;
        private IPhotoService _photoService;
        private IFooterService _footerService;
        private IAboutUsService _aboutUsService;
        private IContactService _contactService;
        private IProjectService _projectService;

        public AdminController(IStreamService streamService, IMissionService missionService, IVisionService visionService, IPersonService personService, ISponsorService sponsorService, IPhotoService photoService, IFooterService footerService, IAboutUsService aboutUsService, IContactService contactService, IProjectService projectService)
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
        public IActionResult AdminPage()
        {

            return View();
        }
        public IActionResult Stream()
        {
            var streamViewModel = new StreamViewModel()
            {
                AdminStream=_streamService.GetAll()
            };

            return View(streamViewModel);   
        }
        public IActionResult Mission()
        {
            var missionViewModel = new MissionViewModel()
            {
                AdminMissions=_missionService.GetAll()
            };

            return View(missionViewModel);   
        }
        public IActionResult Vision()
        {
            var visionViewModel = new VisionViewModel()
            {
                AdminVision=_visionService.GetAll()
            };
            
            return View(visionViewModel);
        }
        public IActionResult Person()
        {
            var personViewModel = new PersonViewModel()
            {
                AdminPersons=_personService.GetAll()
            };
            
            return View(personViewModel);
        }
        public IActionResult Sponsor()
        {
            var sponsorViewModel = new SponsorViewModel()
            {
                AdminSponsor=_sponsorService.GetAll()
            };
            
            return View(sponsorViewModel);
        }
        public IActionResult Photos() 
        {
            var photoViewModel= new PhotoViewModel()
            {
                AdminPhoto=_photoService.GetAll()
            };
            
            return View(photoViewModel);
        }
        public IActionResult Footer()
        {
            var footerViewModel = new FooterViewModel() 
            {
                AdminFooters=_footerService.GetAll()
            };
            
            return View(footerViewModel);
        }

        public IActionResult AboutUs()
        { 
            var aboutUsViewModel = new AboutUsViewModel()
            {
                AdminAboutUsses=_aboutUsService.GetAll()
            };
            
            return View(aboutUsViewModel);
        }
        public IActionResult Contact ()
        {
            var contactViewModel = new ContactViewModel ()
            {
                AdminContacts=_contactService.GetAll()
            };
            return View(contactViewModel);
        }
        public IActionResult Project ()
        {
            var projectViewModel = new ProjectViewModel ()
            {
                AdminProjects=_projectService.GetAll()
            };
            return View(projectViewModel);
        }

        [HttpGet]
        public IActionResult CreateStream()
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult CreateStream(StreamModel streamModel)
        {
            if(ModelState.IsValid)
            {
                var entity = new Entity.Stream() //System.IO kütüphanesinin Stream özelliğinden dolayı override edilemediği için Entity koyuldu.
                {
                    StreamUrl=streamModel.StreamUrl
                };


                _streamService.Create(entity);
                return RedirectToAction("Stream");
            }
            return View(streamModel);
        }

        [HttpGet]
        public IActionResult CreateMission()
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult CreateMission(MissionModel missionModel)
        {
            if(ModelState.IsValid)
            {
                var entity = new Mission()
                {
                    MissionText = missionModel.MissionText
                };


                _missionService.Create(entity);
                return RedirectToAction("Mission"); 
            }
            return View(missionModel);
           
        }
        [HttpGet]
        public IActionResult CreateVision()
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult CreateVision(VisionModel visionModel)
        {
            if(ModelState.IsValid)
            {
                var entity = new Vision()
                {
                    VisionText=visionModel.VisionText
                };


                _visionService.Create(entity);
                return RedirectToAction("Vision"); 
            }
            return View(visionModel);
        }

        [HttpGet]
        public IActionResult CreatePerson()
        { 
            return View(); 
        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePerson(PersonModel personModel, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                var entity = new Person()
                {
                    PersonFullName=personModel.PersonFullName,
                    PersonUniversity=personModel.PersonUniversity,
                    PersonUniversityDepartmant=personModel.PersonUniversityDepartmant,
                    PersonJob=personModel.PersonJob,

                };

                if(file!=null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.PersonPhoto = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream); //a senkron method oldugundan await olarak durdurdum ve methodun başına async ekledik ve Task içerisine dönüş degerini yazdık
                    }
                }

                _personService.Create(entity);
                return RedirectToAction("Person"); 
            }
            return View (personModel);
            
        }

        [HttpGet]
        public IActionResult CreateSponsor()
        { 
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateSponsor(SponsorModel sponsorModel, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                var entity = new Sponsor()
                {
                    SponsorName=sponsorModel.SponsorName,
                    SponsorTitle=sponsorModel.SponsorTitle,
                    SponsorUrl=sponsorModel.SponsorUrl
                };

                if(file!=null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.SponsorLogo = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream); //a senkron method oldugundan await olarak durdurdum ve methodun başına async ekledik ve Task içerisine dönüş degerini yazdık
                    }
                }

                _sponsorService.Create(entity);
                return RedirectToAction("Sponsor"); 
            }
            return View(sponsorModel);
            
        }

         [HttpGet]
        public IActionResult CreatePhoto()
        { 
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhoto(PhotoModel photoModel, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                var entity = new Photo()
                {

                };

                if (file!=null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.PhotoImageUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                    using(var stream = new FileStream(path,FileMode.Create))
                    { 
                        await file.CopyToAsync(stream); 
                    } 
                }

                _photoService.Create(entity);
                return RedirectToAction("Photos"); 
            }
            return View (photoModel);
        }

        [HttpGet]
        public IActionResult CreateFooter()
        { 
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooter(FooterModel footerModel, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                var entity = new Footer()
                {
                    InstagramLink = footerModel.InstagramLink,
                    LinkedinLink = footerModel.LinkedinLink,
                    TwitterLink = footerModel.TwitterLink,
                    YoutubeLink = footerModel.YoutubeLink,
                    Mail = footerModel.Mail,
                    Adress=footerModel.Adress,
                    CompanyName = footerModel.CompanyName
                };

                if(file!=null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.LogoUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream); //a senkron method oldugundan await olarak durdurdum ve methodun başına async ekledik ve Task içerisine dönüş degerini yazdık
                    }
                }


                _footerService.Create(entity);
                return RedirectToAction("Footer"); 
            }
            return View (footerModel);            
        }

        [HttpGet]
        public IActionResult CreateAboutUs()
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult CreateAboutUs(AboutUsModel aboutUsModel)
        {
            if(ModelState.IsValid)
            {
                var entity = new AboutUs()
                {
                    AboutUsTitle=aboutUsModel.AboutUsTitle,
                    AboutUsText=aboutUsModel.AboutUsText
                };


                _aboutUsService.Create(entity);
                return RedirectToAction("AboutUs"); 
            }
            return View (aboutUsModel);
        }
        [HttpGet]
        public IActionResult CreateProject()
        { 
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectModel projectModel, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                var entity = new Project()
                {
                    ProjectName=projectModel.ProjectName,
                    ProjectDescription=projectModel.ProjectDescription,
                    ProjectYoutubeUrl=projectModel.ProjectYoutubeUrl
                };

                if(file!=null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.ProjectPhoto = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream); //a senkron method oldugundan await olarak durdurdum ve methodun başına async ekledik ve Task içerisine dönüş degerini yazdık
                    }
                }

                _projectService.Create(entity);
                return RedirectToAction("Project"); 
            }
            return View (projectModel);
        }

        [HttpGet]
        public IActionResult EditStream(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var entity = _streamService.GetByID((int)id);

            if(entity==null)
            {
                return NotFound();
            }

            var streamModel = new StreamModel()
            {
                StreamID=entity.StreamID,
                StreamUrl=entity.StreamUrl
            };
            return View(streamModel);
        }
        [HttpPost]
        public IActionResult EditStream(StreamModel streamModel)
        {
            if(ModelState.IsValid)
            {
                var entity = _streamService.GetByID(streamModel.StreamID);
                if (entity==null)
                {
                    return NotFound();
                }

                entity.StreamUrl=streamModel.StreamUrl;

                _streamService.Update(entity);
                return RedirectToAction("Stream");
            }
            return View (streamModel);
        }

        [HttpGet]
        public IActionResult EditMission(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var entity = _missionService.GetByID((int)id);

            if(entity==null)
            {
                return NotFound();
            }

            var missionModel = new MissionModel()
            {
                MissionID=entity.MissionID,
                MissionText=entity.MissionText
            };
            return View(missionModel);
        }
        [HttpPost]
        public IActionResult EditMission(MissionModel missionModel)
        {
            if(ModelState.IsValid)
            {
                var entity = _missionService.GetByID(missionModel.MissionID);
                if (entity==null)
                {
                    return NotFound();
                }

                entity.MissionText=missionModel.MissionText;

                _missionService.Update(entity);
                return RedirectToAction("Mission");
            }
            return View(missionModel);
           
        }
        [HttpGet]
        public IActionResult EditVision(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var entity = _visionService.GetByID((int)id);

            if(entity==null)
            {
                return NotFound();
            }

            var visionModel = new VisionModel()
            {
                VisionID=entity.VisionID,
                VisionText=entity.VisionText
            };
            return View(visionModel);
        }
        [HttpPost]
        public IActionResult EditVision(VisionModel visionModel)
        {
            if(ModelState.IsValid)
            {
                var entity = _visionService.GetByID(visionModel.VisionID);
                if (entity==null)
                {
                    return NotFound();
                }

                entity.VisionText=visionModel.VisionText;

                _visionService.Update(entity);
                return RedirectToAction("Vision");
            }
            return View (visionModel);
        }
        [HttpGet]
        public IActionResult EditPerson(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var entity = _personService.GetByID((int)id);

            if(entity==null)
            {
                return NotFound();
            }

            var personModel = new PersonModel()
            {
                PersonID=entity.PersonID,
                PersonFullName=entity.PersonFullName,
                PersonUniversity=entity.PersonUniversity,
                PersonUniversityDepartmant=entity.PersonUniversityDepartmant,
                PersonJob=entity.PersonJob,
                PersonPhoto=entity.PersonPhoto
            };
            return View(personModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditPerson(PersonModel personModel, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                var entity = _personService.GetByID(personModel.PersonID);
                if (entity==null)
                {
                    return NotFound();
                }

                entity.PersonID=personModel.PersonID;
                entity.PersonFullName=personModel.PersonFullName;
                entity.PersonUniversity=personModel.PersonUniversity;
                entity.PersonUniversityDepartmant=personModel.PersonUniversityDepartmant;
                entity.PersonJob=personModel.PersonJob;

                if (file!=null)
                {
                    var extention = Path.GetExtension(file.FileName); //gelen dosyanın uzantısını burada alıyoruz.
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}"); //benzersiz bir isim oluşturmak için 
                    entity.PersonPhoto = randomName; //veritabanına gönderildi
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName); //Projenin Ui kısmının yolunu getirdik ilk olarak
                                                                                                            //daha sonra nereye gideceğini ve nei götüreceğini söylşedik.
                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream); //a senkron method oldugundan await olarak durdurdum ve methodun başına async ekledik ve Task içerisine dönüş degerini yazdık
                    }
                }                       

                _personService.Update(entity);
                return RedirectToAction("Person");
            }
            return View(personModel);
        }
        [HttpGet]
        public IActionResult EditSponsor(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var entity = _sponsorService.GetByID((int)id);

            if(entity==null)
            {
                return NotFound();
            }

            var sponsorModel = new SponsorModel()
            {
                SponsorID=entity.SponsorID,
                SponsorName=entity.SponsorName,
                SponsorTitle=entity.SponsorTitle,
                SponsorLogo=entity.SponsorLogo,
                SponsorUrl=entity.SponsorUrl
            };
            return View(sponsorModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditSponsor(SponsorModel sponsorModel, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                var entity = _sponsorService.GetByID(sponsorModel.SponsorID);
                if (entity==null)
                {
                    return NotFound();
                }

                entity.SponsorID=sponsorModel.SponsorID;
                entity.SponsorName=sponsorModel.SponsorName;
                entity.SponsorTitle=sponsorModel.SponsorTitle;
                entity.SponsorUrl=sponsorModel.SponsorUrl;

                if(file!=null)
                {
                    var extention = Path.GetExtension(file.FileName); 
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}"); 
                    entity.SponsorLogo = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName); 

                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream); 
                    }
                }

                _sponsorService.Update(entity);
                return RedirectToAction("Sponsor");
            }
            return View (sponsorModel);
        }
        [HttpGet]
        public IActionResult EditPhotos(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var entity = _photoService.GetByID((int)id);

            if(entity==null)
            {
                return NotFound();
            }

            var photoModel = new PhotoModel()
            {
                PhotoID=entity.PhotoID,
                PhotoImageUrl=entity.PhotoImageUrl
            };
            return View(photoModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditPhotos(PhotoModel photoModel, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                var entity = _photoService.GetByID(photoModel.PhotoID);
                if (entity==null)
                {
                    return NotFound();
                }

                entity.PhotoID=photoModel.PhotoID;

                if (file!=null)
                {
                    var extention = Path.GetExtension(file.FileName); 
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}"); 
                    entity.PhotoImageUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName); 

                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream); 
                    }
                }

                _photoService.Update(entity);
                return RedirectToAction("Photos");
            }
            return View (photoModel);
        }
        [HttpGet]
        public IActionResult EditFooter(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var entity = _footerService.GetByID((int)id);

            if(entity==null)
            {
                return NotFound();
            }

            var footerModel = new FooterModel()
            {
                FooterID=entity.FooterID,
                InstagramLink=entity.InstagramLink,
                LinkedinLink=entity.LinkedinLink,
                TwitterLink=entity.TwitterLink,
                YoutubeLink=entity.YoutubeLink,
                Mail=entity.Mail,
                Adress=entity.Adress,
                LogoUrl=entity.LogoUrl,
                CompanyName=entity.CompanyName,
            };
            return View(footerModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditFooter(FooterModel footerModel, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                var entity = _footerService.GetByID(footerModel.FooterID);
                if (entity==null)
                {
                    return NotFound();
                }

                entity.FooterID=footerModel.FooterID;
                entity.InstagramLink=footerModel.InstagramLink;
                entity.LinkedinLink=footerModel.LinkedinLink;
                entity.TwitterLink=footerModel.TwitterLink;
                entity.YoutubeLink=footerModel.YoutubeLink;
                entity.Mail=footerModel.Mail;
                entity.Adress=footerModel.Adress;
                entity.CompanyName=footerModel.CompanyName;

                if(file!=null)
                {
                    var extention = Path.GetExtension(file.FileName); 
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}"); 
                    entity.LogoUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName); 

                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream); 
                    }
                }

                _footerService.Update(entity);
                return RedirectToAction("Footer");
            }
            return View (footerModel);
        }
        [HttpGet]
        public IActionResult EditAboutUs(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var entity = _aboutUsService.GetByID((int)id);

            if(entity==null)
            {
                return NotFound();
            }

            var aboutUsModel = new AboutUsModel()
            {
                AboutUsID=entity.AboutUsID,
                AboutUsTitle=entity.AboutUsTitle,
                AboutUsText=entity.AboutUsText
            };
            return View(aboutUsModel);
        }
        [HttpPost]
        public IActionResult EditAboutUs(AboutUsModel aboutUsModel)
        {
            if(ModelState.IsValid)
            {
                var entity = _aboutUsService.GetByID(aboutUsModel.AboutUsID);
                if (entity==null)
                {
                    return NotFound();
                }

                entity.AboutUsTitle=aboutUsModel.AboutUsTitle;
                entity.AboutUsText=aboutUsModel.AboutUsText;

                _aboutUsService.Update(entity);
                return RedirectToAction("AboutUs");
            }
            return View (aboutUsModel);
        }

        [HttpGet]
        public IActionResult EditProject(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var entity = _projectService.GetByID((int)id);

            if(entity==null)
            {
                return NotFound();
            }

            var projectModel = new ProjectModel()
            {
                ProjectID=entity.ProjectID,
                ProjectName=entity.ProjectName,
                ProjectPhoto=entity.ProjectPhoto,
                ProjectDescription=entity.ProjectDescription,
                ProjectYoutubeUrl=entity.ProjectYoutubeUrl
            };
            return View(projectModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditProject(ProjectModel projectModel, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                var entity = _projectService.GetByID(projectModel.ProjectID);
                if (entity==null)
                {
                    return NotFound();
                }
                
                entity.ProjectID=projectModel.ProjectID;
                entity.ProjectName=projectModel.ProjectName;
                entity.ProjectDescription=projectModel.ProjectDescription;
                entity.ProjectYoutubeUrl=projectModel.ProjectYoutubeUrl;      

                if (file!=null)
                {
                    var extention = Path.GetExtension(file.FileName); //gelen dosyanın uzantısını burada alıyoruz.
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}"); //benzersiz bir isim oluşturmak için 
                    entity.ProjectPhoto = randomName; //veritabanına gönderildi
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName); //Projenin Ui kısmının yolunu getirdik ilk olarak
                                                                                                            //daha sonra nereye gideceğini ve nei götüreceğini söylşedik.
                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream); //a senkron method oldugundan await olarak durdurdum ve methodun başına async ekledik ve Task içerisine dönüş degerini yazdık
                    }
                }                       

                _projectService.Update(entity);
                return RedirectToAction("Project");
            }
            return View (projectModel);
        }

        public IActionResult DeleteStream(int streamId)
        {
            var entity = _streamService.GetByID(streamId);
            if(entity!=null)
            {
                _streamService.Delete(entity);
            }
            return RedirectToAction("Stream");
        }

        public IActionResult DeleteMission(int missionId)
        {
            var entity = _missionService.GetByID(missionId);
            if(entity!=null)
            {
                _missionService.Delete(entity);
            }
            return RedirectToAction("Mission");
        }

        public IActionResult DeleteVision(int visionId)
        {
            var entity = _visionService.GetByID(visionId);
            if(entity!=null)
            {
                _visionService.Delete(entity);
            }
            return RedirectToAction("Vision");
        }

        public IActionResult DeletePerson(int personId)
        {
            var entity = _personService.GetByID(personId);
            if(entity!=null)
            {
                _personService.Delete(entity);
            }
            return RedirectToAction("Person");
        }

        public IActionResult DeleteSponsor(int sponsorId)
        {
            var entity = _sponsorService.GetByID(sponsorId);
            if(entity!=null)
            {
                _sponsorService.Delete(entity);
            }
            return RedirectToAction("Sponsor");
        }

        public IActionResult DeletePhotos(int photoId)
        {
            var entity = _photoService.GetByID(photoId);
            if(entity!=null)
            {
                _photoService.Delete(entity);
            }
            return RedirectToAction("Photos");
        }
        public IActionResult DeleteFooter(int footerId)
        {
            var entity = _footerService.GetByID(footerId);
            if(entity!=null)
            {
                _footerService.Delete(entity);
            }
            return RedirectToAction("Footer");
        }
        public IActionResult DeleteAboutUs(int aboutUsId)
        {
            var entity = _aboutUsService.GetByID(aboutUsId);
            if(entity!=null)
            {
                _aboutUsService.Delete(entity);
            }
            return RedirectToAction("AboutUs");
        }
        public IActionResult DeleteContact(int contactId)
        {
            var entity = _contactService.GetByID(contactId);
            if(entity!=null)
            {
                _contactService.Delete(entity);
            }
            return RedirectToAction("Contact");
        }
        public IActionResult DeleteProject(int projectId)
        {
            var entity = _projectService.GetByID(projectId);
            if(entity!=null)
            {
                _projectService.Delete(entity);
            }
            return RedirectToAction("Project");
        }
    }
}