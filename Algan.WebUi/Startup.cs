using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Algan.Data.Abstract;
using Algan.Data.Concrete.EFCore;
using Microsoft.Extensions.DependencyInjection;
using Algan.Business.Concrete;
using Algan.Business.Abstract;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Algan.WebUi.Identity;
using Microsoft.AspNetCore.Identity;




namespace Algan.WebUi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Algan;Integrated Security=SSPI;"));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options => {
                // for password
                options.Password.RequireDigit =true; //şifrede mutlaka sayısal değer olması
                options.Password.RequireLowercase=true; //mutlaka küçük harf olmalı
                options.Password.RequireUppercase=true;
                options.Password.RequiredLength = 8; //minimum 8 karakter
                options.Password.RequireNonAlphanumeric =false; //alfa numeric karakter olmasın

                //Lockout
                options.Lockout.MaxFailedAccessAttempts = 10; //10 yanlış girişte ban
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //5dk sonra ban açılır
                options.Lockout.AllowedForNewUsers =true;

                options.User.RequireUniqueEmail=true; //benzersiz mail olmalı
                options.SignIn.RequireConfirmedEmail = false; //mail onaylaması
            });

            services.ConfigureApplicationCookie(options => {
                options.LoginPath ="/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath ="/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".Algan.Security.Cookie"
                };
            });
            services.AddScoped<IMissionRepository,EfCoreMissionRepository>();
            services.AddScoped<IMissionService,MissionManager>();

            services.AddScoped<IVisionRepository,EfCoreVisionRepository>();
            services.AddScoped<IVisionService,VisionManager>();

            services.AddScoped<IPersonRepository,EfCorePersonRepository>();
            services.AddScoped<IPersonService,PersonManager>();

            services.AddScoped<ISponsorRepository,EfCoreSponsorRepository>();
            services.AddScoped<ISponsorService,SponsorManager>();

            services.AddScoped<IPhotoRepository,EfCorePhotoRepository>();
            services.AddScoped<IPhotoService,PhotoManager>();

            services.AddScoped<IStreamRepository,EfCoreStreamRepository>();
            services.AddScoped<IStreamService,StreamManager>();

            services.AddScoped<IFooterRepository,EfCoreFooterRepository>();
            services.AddScoped<IFooterService,FooterManager>();

            services.AddScoped<IAboutUsRepository,EfCoreAboutUsRepository>();
            services.AddScoped<IAboutUsService,AboutUsManager>();

            services.AddScoped<IContactRepository,EfCoreContactRepository>();
            services.AddScoped<IContactService,ContactManager>();

            services.AddScoped<IProjectRepository,EfCoreProjectRepository>();
            services.AddScoped<IProjectService,ProjectManager>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles(); //wwwroot altındaki klasörlerin açılması için

            app.UseStaticFiles(new StaticFileOptions {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
                    RequestPath="/modules"
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization(); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/mission/",
                    defaults : new {controller = "Admin", action="Mission"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/mission/{id?}",
                    defaults : new {controller = "Admin", action="EditMission"}
                );

                 endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/vision/",
                    defaults : new {controller = "Admin", action="Vision"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/vision/{id?}",
                    defaults : new {controller = "Admin", action="EditVision"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/person/",
                    defaults : new {controller = "Admin", action="Person"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/person/{id?}",
                    defaults : new {controller = "Admin", action="EditPerson"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/sponsor/",
                    defaults : new {controller = "Admin", action="Sponsor"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/sponsor/{id?}",
                    defaults : new {controller = "Admin", action="EditSponsor"}
                );

                 endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/photos/",
                    defaults : new {controller = "Admin", action="Photos"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/photos/{id?}",
                    defaults : new {controller = "Admin", action="EditPhotos"}
                );
                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/stream/",
                    defaults : new {controller = "Admin", action="Stream"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/stream/{id?}",
                    defaults : new {controller = "Admin", action="EditStream"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/footer/",
                    defaults : new {controller = "Admin", action="Footer"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/footer/{id?}",
                    defaults : new {controller = "Admin", action="EditFooter"}
                );
                
                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/project/",
                    defaults : new {controller = "Admin", action="Project"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/project/{id?}",
                    defaults : new {controller = "Admin", action="EditProject"}
                );
                 endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/aboutus/",
                    defaults : new {controller = "Admin", action="AboutUs"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"admin/aboutUs/{id?}",
                    defaults : new {controller = "Admin", action="EditAboutUs"}
                );
                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"home/contact/",
                    defaults : new {controller = "Home", action="Contact"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"home/contact/{id?}",
                    defaults : new {controller = "Home", action="Contact"}
                );
                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"home/project/",
                    defaults : new {controller = "Home", action="Project"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"home/project/{id?}",
                    defaults : new {controller = "Home", action="ProjectDetail"}
                );

                endpoints.MapControllerRoute(
                    name : "defaulf",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                );

                
            });
        }
    }
}
