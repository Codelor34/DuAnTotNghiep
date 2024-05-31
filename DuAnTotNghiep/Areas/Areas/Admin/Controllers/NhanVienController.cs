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
    [Route("Admin/NhanVien")]
    public class NhanVienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NhanVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NhanVien.Include(n => n.Admins).Include(n => n.Users);
            return View(await applicationDbContext.ToListAsync());
        }

        [Route("Details")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .Include(n => n.Admins)
                .Include(n => n.Users)
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            var khachHangUsers = _context.Users.Where(u => u.Role == "Nhân viên").Select(u => u.UserName).Except(_context.User_Khachhang.Select(uk => uk.UserName)).ToList();
            ViewData["HoTenAdmin"] = new SelectList(_context.Admins, "HoTenAdmin", "HoTenAdmin");
            ViewData["UserName"] = new SelectList(khachHangUsers);
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNV,HoTenNV,HoTenAdmin,Sdt,Email,DiaChi,NgaySinh,UserName")] NhanVien nhanVien)
        {
            if (!ModelState.IsValid)
            {
                nhanVien.MaNV = Guid.NewGuid();
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoTenAdmin"] = new SelectList(_context.Admins, "HoTenAdmin", "HoTenAdmin", nhanVien.HoTenAdmin);
            ViewData["UserName"] = new SelectList(_context.Users, "UserName", "UserName", nhanVien.UserName);
            return View(nhanVien);
        }

        [Route("Edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            ViewData["HoTenAdmin"] = new SelectList(_context.Admins, "HoTenAdmin", "HoTenAdmin", nhanVien.HoTenAdmin);
            ViewData["UserName"] = new SelectList(_context.Users, "UserName", "UserName", nhanVien.UserName);
            return View(nhanVien);
        }

        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("MaNV,HoTenNV,HoTenAdmin,Sdt,Email,DiaChi,NgaySinh,UserName")] NhanVien nhanVien)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.MaNV))
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
            ViewData["HoTenAdmin"] = new SelectList(_context.Admins, "HoTenAdmin", "HoTenAdmin", nhanVien.HoTenAdmin);
            ViewData["UserName"] = new SelectList(_context.Users, "UserName", "UserName", nhanVien.UserName);
            return View(nhanVien);
        }

        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .Include(n => n.Admins)
                .Include(n => n.Users)
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.NhanVien == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NhanVien'  is null.");
            }
            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien != null)
            {
                _context.NhanVien.Remove(nhanVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(Guid id)
        {
          return (_context.NhanVien?.Any(e => e.MaNV == id)).GetValueOrDefault();
        }
    }
}
