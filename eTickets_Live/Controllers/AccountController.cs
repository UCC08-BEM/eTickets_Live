using eTickets_Live.Data;
using eTickets_Live.Data.ViewModels;
using eTickets_Live.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eTickets_Live.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInuser;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInuser, AppDbContext context)
        {
            _userManager = userManager;
            _signInuser = signInuser;
            _context = context;
        }

        public IActionResult Login()
        {
            var response = new LoginVM();

            return View();
        }
    }
}
