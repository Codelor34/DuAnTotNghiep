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
            var u = _context.Users.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password) && (x.Role == "Quản lý" ||x.Role=="Nhân viên") ).FirstOrDefault();
            var p = _context.Users.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password) && x.Role == "Khách hàng").FirstOrDefault();
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
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([Bind("UserName,Password,Role")] Users users)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    var SignUp = _context.Users.FirstOrDefault(a => a.UserName == users.UserName);
                    if (SignUp != null)
                    {
                        TempData["SuccessMessage"] = "Tài khoản này đã tồn tại";
                        return View(users);
                    }
                    _context.Add(users);

                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = null;
                    return RedirectToAction(nameof(Login));
                }
                return View(users);
            }

            
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           
        }
    }
}
