using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Algan.WebUi.Identity;
using Algan.WebUi.Models;
using System.Threading.Tasks;

namespace Algan.WebUi.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register (RegisterModel registerModel)  
        {
            if(ModelState.IsValid)
            {
                if(!ModelState.IsValid)
                {
                    return View(registerModel);
                }

                var user = new User ()
                {
                    UserName=registerModel.UserName,
                    Email=registerModel.Email
                };

                var result = await _userManager.CreateAsync(user,registerModel.Password);
                if(result.Succeeded)
                {
                    //genrate token - mail ile post

                    return RedirectToAction("Login","Account");
                }

                ModelState.AddModelError("","Bilinmeyen bir hata oldu tekrar deneyiniz.");
                return View(registerModel);
            }
            return View(registerModel);
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInModel logInModel)
        {
            if(!ModelState.IsValid)
            {
                return View(logInModel);
            }

            var user = await _userManager.FindByNameAsync(logInModel.UserName);
            if(user==null)
            {
                ModelState.AddModelError("","Kullanıcı adı bulunamadı."); //validation sonraso doldurulacak
                return View(logInModel);
            }

            var result = await _signInManager.PasswordSignInAsync(user, logInModel.Password, true, false);

            if(result.Succeeded)
            {
                return RedirectToAction("AdminPage","Admin");
            }
            ModelState.AddModelError("","Girilen Kullanıcı Adı veya Paralo Haatalı");


            return View(logInModel);
        }
        
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction ("Index","Home");
        }
    }
}