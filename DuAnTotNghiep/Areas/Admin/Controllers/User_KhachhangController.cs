using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DuAnTotNghiep.Data;
using DuAnTotNghiep.Models;

namespace DuAnTotNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/User_Khachhang")]
    public class User_KhachhangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public User_KhachhangController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.User_Khachhang.Include(u => u.KhachHang).Include(u => u.Users);
            return View(await applicationDbContext.ToListAsync());
        }

        [Route("Details")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.User_Khachhang == null)
            {
                return NotFound();
            }

            var user_Khachhang = await _context.User_Khachhang
                .Include(u => u.KhachHang)
                .Include(u => u.Users)
                .FirstOrDefaultAsync(m => m.ID_User == id);
            if (user_Khachhang == null)
            {
                return NotFound();
            }

            return View(user_Khachhang);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            var existingHoTen = _context.User_Khachhang.Select(uk => uk.Hoten).ToList();
            var khachHang = _context.KhachHang.Select(kh => kh.HoTen).Distinct().Where(ht => !existingHoTen.Contains(ht)).ToList();
            var khachHangUsers = _context.Users.Where(u => u.Role == "Khách hàng").Select(u => u.UserName).Except(_context.User_Khachhang.Select(uk => uk.UserName)).ToList();
            ViewData["Hoten"] = new SelectList(khachHang);
            ViewData["UserName"] = new SelectList(khachHangUsers);

            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_User,Hoten,UserName")] User_Khachhang user_Khachhang)
        {
            var obj = _context.User_Khachhang.FirstOrDefault(a => a.Hoten == user_Khachhang.Hoten && a.UserName == user_Khachhang.UserName);
            if (!ModelState.IsValid && obj == null)
            {
                user_Khachhang.ID_User = Guid.NewGuid();
                _context.Add(user_Khachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Messinger"] = "Tài khoản đã tồn tại";
            }
            ViewData["Hoten"] = new SelectList(_context.KhachHang, "HoTen", "HoTen", user_Khachhang.Hoten);
            ViewData["UserName"] = new SelectList(_context.Users, "UserName", "UserName", user_Khachhang.UserName);
            return View(user_Khachhang);
        }

        [Route("Edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.User_Khachhang == null)
            {
                return NotFound();
            }

            var user_Khachhang = await _context.User_Khachhang.FindAsync(id);
            if (user_Khachhang == null)
            {
                return NotFound();
            }
            ViewData["Hoten"] = new SelectList(_context.KhachHang, "HoTen", "HoTen", user_Khachhang.Hoten);
            ViewData["UserName"] = new SelectList(_context.Users, "UserName", "UserName", user_Khachhang.UserName);
            return View(user_Khachhang);
        }

        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ID_User,Hoten,UserName")] User_Khachhang user_Khachhang)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_Khachhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_KhachhangExists(user_Khachhang.ID_User))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Hoten"] = new SelectList(_context.KhachHang, "HoTen", "HoTen", user_Khachhang.Hoten);
            ViewData["UserName"] = new SelectList(_context.Users, "UserName", "UserName", user_Khachhang.UserName);
            return View(user_Khachhang);
        }

        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.User_Khachhang == null)
            {
                return NotFound();
            }

            var user_Khachhang = await _context.User_Khachhang
                .Include(u => u.KhachHang)
                .Include(u => u.Users)
                .FirstOrDefaultAsync(m => m.ID_User == id);
            if (user_Khachhang == null)
            {
                return NotFound();
            }

            return View(user_Khachhang);
        }

        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.User_Khachhang == null)
            {
                return Problem("Entity set 'ApplicationDbContext.User_Khachhang'  is null.");
            }
            var user_Khachhang = await _context.User_Khachhang.FindAsync(id);
            if (user_Khachhang != null)
            {
                _context.User_Khachhang.Remove(user_Khachhang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_KhachhangExists(Guid id)
        {
          return (_context.User_Khachhang?.Any(e => e.ID_User == id)).GetValueOrDefault();
        }
    }
}
