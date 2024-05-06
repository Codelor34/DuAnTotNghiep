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
            var u = _context.Users.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password)&& x.Role == "Quản lý").FirstOrDefault();
            var p = _context.Users.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password) && x.Role == "Khách hàng").FirstOrDefault();
            if (u != null && p == null)
            {
              
                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}
