using DuAnTotNghiep.Data;
using DuAnTotNghiep.Models;
using Microsoft.AspNetCore.Mvc;

namespace DuAnTotNghiep.Controllers
{
    public class AccessController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccessController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users user)
        {
            var u = _context.Users.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password) && x.Role == "Quản Lý").FirstOrDefault();
            var p = _context.Users.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password) && x.Role == "Khách Hàng").FirstOrDefault();
            if (u != null && p == null)
            {
                HttpContext.Session.SetString("Username", u.UserName.ToString());
                return RedirectToAction("Index", "Home");
            }
            else if (p != null && u == null)
            {
                HttpContext.Session.SetString("Username", p.UserName.ToString());
                return RedirectToAction("Privacy", "Home");
            }
            return View();
        }
    }
}
