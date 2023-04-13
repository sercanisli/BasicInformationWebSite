using System.Linq;
using Algan.Entity;
using Microsoft.EntityFrameworkCore;

namespace Algan.Data.Concrete.EFCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context= new AlganContext();
            if(context.Database.GetPendingMigrations().Count()==0) //Migrationslar uygulandı mı?
            {
                if(context.Missions.Count()==0)
                {
                    context.Missions.AddRange(Missions);
                }
                if(context.Visions.Count()==0)
                {
                    context.Visions.AddRange(Visions);
                }
                if(context.Persons.Count()==0)
                {
                    context.Persons.AddRange(Persons);
                }
                if(context.Sponsors.Count()==0)
                {
                    context.Sponsors.AddRange(Sponsors);
                }
                if(context.Photos.Count()==0)
                {
                    context.Photos.AddRange(Photos);
                }
                if(context.Streams.Count()==0)
                {
                    context.Streams.AddRange(Streams);
                }
                if(context.AboutUsses.Count()==0)
                {
                    context.Footers.AddRange(Footers);
                }
                if(context.Footers.Count()==0)
                {
                    context.AboutUsses.AddRange(AboutUsses);
                }
                if(context.Contacts.Count()==0)
                {
                    context.Contacts.AddRange(Contacts);
                }
                if(context.Projects.Count()==0)
                {
                    context.Projects.AddRange(Projects);
                }
                
            }
            context.SaveChanges();
        }
        private static Mission[] Missions={
            new Mission() {MissionText="Atamızın İstikbal Göklerdedir Sözünün Sonsuza Kadar Bekçisi olacağız.."}
        };
        private static Vision[] Visions={
            new Vision() {VisionText="Lorem Ipsum, masaüstü yayıncılık ve basın yayın sektöründe kullanılan taklit yazı bloğu olarak tanımlanır. Lipsum, oluşturulacak şablon ve taslaklarda içerik yerine geçerek yazı bloğunu doldurmak için kullanılır."}
        };
        private static Person[] Persons={
            new Person() {PersonFullName="Sercan ISLI",PersonUniversity="PAU",PersonUniversityDepartmant="YBS",PersonJob="Görev",PersonPhoto="1.jpg" }
        };
        private static Sponsor[] Sponsors={
            new Sponsor() {SponsorName="RoakGame",SponsorTitle="Ana Sponsor",SponsorLogo="logo.png",SponsorUrl="www.roakgame.com" }
        };
        private static Photo[] Photos={
            new Photo() {PhotoImageUrl="2.jpg"}
        };
        private static Stream[] Streams={
            new Stream() {StreamUrl="youtube.com/asd"}
        };
        private static Footer[] Footers={
            new Footer() {InstagramLink="https://www.instagram.com/algantk/", LinkedinLink="https://tr.linkedin.com/company/algan-teknoloji-takimi", TwitterLink="https://twitter.com/algantk", YoutubeLink="https://www.youtube.com/channel/UCGx0fiyvdoYOzTZCf1ADt2w", Mail="	algantakimi@gmail.com",Adress="Denizl,", LogoUrl="1.jpg",CompanyName="AlganTk"}
        };
        
        private static AboutUs[] AboutUsses={
            new AboutUs() {AboutUsText="Hakkimizda"} 
        };
        private static Contact[] Contacts={
            new Contact() {FullName="Sercan ISLI", Email="sercanislii@gmail.com", Topic="Website", Message="Mesaj"} 
        };
        private static Project[] Projects={
            new Project() {ProjectName="Proje Adı", ProjectPhoto="Kapak Fotosu", ProjectDescription="Proje Açıklaması", ProjectYoutubeUrl="Youtube Url'si"} 
        };
       
    }
}