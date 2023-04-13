using Microsoft.EntityFrameworkCore;
using Algan.Entity;


namespace Algan.Data.Concrete.EFCore
{
    public class AlganContext : DbContext
    {
        public DbSet<Mission> Missions {get;set;}
        public DbSet<Vision> Visions {get;set;}
        public DbSet<Person> Persons {get;set;}
        public DbSet<Sponsor> Sponsors {get;set;}
        public DbSet<Photo> Photos {get;set;}
        public DbSet<Stream> Streams {get; set;}
        public DbSet<Footer> Footers {get; set;}
        public DbSet<AboutUs> AboutUsses {get; set;}
        public DbSet<Contact> Contacts {get; set;}
        public DbSet<Project> Projects {get; set;}







        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Algan;Integrated Security=SSPI;");
        }
    }
}