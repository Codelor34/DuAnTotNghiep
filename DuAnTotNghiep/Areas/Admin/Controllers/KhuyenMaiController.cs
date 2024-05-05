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
    [Route("Admin/KhuyenMai")]
    public class KhuyenMaiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KhuyenMaiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KhuyenMai.Include(k => k.Admins);
            return View(await applicationDbContext.ToListAsync());
        }

        [Route("Details")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.KhuyenMai == null)
            {
                return NotFound();
            }

            var khuyenMai = await _context.KhuyenMai
                .Include(k => k.Admins)
                .FirstOrDefaultAsync(m => m.ID_Km == id);
            if (khuyenMai == null)
            {
                return NotFound();
            }

            return View(khuyenMai);
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
        public async Task<IActionResult> Create([Bind("ID_Km,TruongTrinhKM,MoTa,HoTenAdmin")] KhuyenMai khuyenMai)
        {
            if (ModelState.IsValid)
            {
                khuyenMai.ID_Km = Guid.NewGuid();
                _context.Add(khuyenMai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoTenAdmin"] = new SelectList(_context.Admins, "HoTenAdmin", "HoTenAdmin", khuyenMai.HoTenAdmin);
            return View(khuyenMai);
        }

        [Route("Edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.KhuyenMai == null)
            {
                return NotFound();
            }

            var khuyenMai = await _context.KhuyenMai.FindAsync(id);
            if (khuyenMai == null)
            {
                return NotFound();
            }
            ViewData["HoTenAdmin"] = new SelectList(_context.Admins, "HoTenAdmin", "HoTenAdmin", khuyenMai.HoTenAdmin);
            return View(khuyenMai);
        }

        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID_Km,TruongTrinhKM,MoTa,HoTenAdmin")] KhuyenMai khuyenMai)
        {
            if (id != khuyenMai.ID_Km)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khuyenMai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhuyenMaiExists(khuyenMai.ID_Km))
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
            ViewData["HoTenAdmin"] = new SelectList(_context.Admins, "HoTenAdmin", "HoTenAdmin", khuyenMai.HoTenAdmin);
            return View(khuyenMai);
        }

        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.KhuyenMai == null)
            {
                return NotFound();
            }

            var khuyenMai = await _context.KhuyenMai
                .Include(k => k.Admins)
                .FirstOrDefaultAsync(m => m.ID_Km == id);
            if (khuyenMai == null)
            {
                return NotFound();
            }

            return View(khuyenMai);
        }

        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.KhuyenMai == null)
            {
                return Problem("Entity set 'ApplicationDbContext.KhuyenMai'  is null.");
            }
            var khuyenMai = await _context.KhuyenMai.FindAsync(id);
            if (khuyenMai != null)
            {
                _context.KhuyenMai.Remove(khuyenMai);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhuyenMaiExists(Guid id)
        {
          return (_context.KhuyenMai?.Any(e => e.ID_Km == id)).GetValueOrDefault();
        }
    }
}
