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
    [Route("Admin/KhachHang")]
    public class KhachHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KhachHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KhachHang.Include(k => k.Admins);
            return View(await applicationDbContext.ToListAsync());
        }

        [Route("Details")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.KhachHang == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHang
                .Include(k => k.Admins)
                .FirstOrDefaultAsync(m => m.HoTen == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            ViewData["HoTenAdmin"] = new SelectList(_context.Admins, "HoTenAdmin", "HoTenAdmin");
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoTen,Sdt,Email,DiaChi,NgaySinh,HoTenAdmin")] KhachHang khachHang)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(khachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoTenAdmin"] = new SelectList(_context.Admins, "HoTenAdmin", "HoTenAdmin", khachHang.HoTenAdmin);
            return View(khachHang);
        }

        [Route("Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.KhachHang == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHang.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            ViewData["HoTenAdmin"] = new SelectList(_context.Admins, "HoTenAdmin", "HoTenAdmin", khachHang.HoTenAdmin);
            return View(khachHang);
        }

        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HoTen,Sdt,Email,DiaChi,NgaySinh,HoTenAdmin")] KhachHang khachHang)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachHangExists(khachHang.HoTen))
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
            ViewData["HoTenAdmin"] = new SelectList(_context.Admins, "HoTenAdmin", "HoTenAdmin", khachHang.HoTenAdmin);
            return View(khachHang);
        }

        [Route("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.KhachHang == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHang
                .Include(k => k.Admins)
                .FirstOrDefaultAsync(m => m.HoTen == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.KhachHang == null)
            {
                return Problem("Entity set 'ApplicationDbContext.KhachHang'  is null.");
            }
            var khachHang = await _context.KhachHang.FindAsync(id);
            if (khachHang != null)
            {
                _context.KhachHang.Remove(khachHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachHangExists(string id)
        {
          return (_context.KhachHang?.Any(e => e.HoTen == id)).GetValueOrDefault();
        }
    }
}
