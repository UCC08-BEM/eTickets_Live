using eTickets_Live.Data;
using eTickets_Live.Data.Static;
using eTickets_Live.Data.ViewModels;
using eTickets_Live.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eTickets_Live.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInuser, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInuser;
            _context = context;
        }

        public IActionResult Login()
        {
            // Kullanılan şifre Coding@1234? (admin/user)
            var response = new LoginVM();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            // kullanıcının var olup olmadığını EMail sorgulayarak yapıyor
            var user = await _userManager.FindByEmailAsync(loginVM.EMailAddress);

            if (user != null)  // herhangi bir kayıt varsa
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if (passwordCheck) // Password de uygunsa 
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                    if (result.Succeeded) // işlem başarılı ise
                    {
                        return RedirectToAction("Index", "Movies");

                    }
                }

                TempData["Error"] = "Yanlış kullanıcı bilgisi...Tekrar deneyiniz...";

                return View(loginVM);
            }

            TempData["Error"] = "Yanlış kullanıcı bilgisi...Tekrar deneyiniz...";

            return View(loginVM);

        } 

        // Register bölümü

        public IActionResult Register()
        {
            var response=new RegisterVM();

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);

            if (user != null)  // herhangi bir kayıt varsa
            {
                TempData["Error"] = "Bu isimde bir kayıt bulunmaktadır... Lütfen değiştiriniz";
                return View(registerVM);
            }

            // eğer yoksa yaratılacak bir kullanıcı
            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };

            // Yaratılacak kullanıcı için görevi IdentityFramework ün metoduna bırakıyoruz
            var newUserResponse= await _userManager.CreateAsync(newUser,registerVM.Password);

            if (newUserResponse.Succeeded) // Yaptığı işlem başarılı ise
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                
                return View("RegisterCompleted");
            }

            return View(registerVM);

        }

        // Logout Bölümü (göndericek olan yer Logout Butonu)
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Movies");
        }



    }
}
