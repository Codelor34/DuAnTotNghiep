using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DuAnTotNghiep.Data;
using DuAnTotNghiep.Models;
using Microsoft.Identity.Client;

namespace DuAnTotNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
  
    [Route("Admin/DonHang")]
    public class DonHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return _context.DonHang != null ?
                        View(await _context.DonHang.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.DonHang'  is null.");
        }

        [Route("Details")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.DonHang == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .FirstOrDefaultAsync(m => m.ID_Don_Hang == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNV")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                donHang.ID_Don_Hang = Guid.NewGuid();
                _context.Add(donHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donHang);
        }

        [Route("Edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.DonHang == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            return View(donHang);
        }

        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DonHang donHang)
        {
            var Edit = _context.DonHang.FirstOrDefault(a => a.ID_Don_Hang == donHang.ID_Don_Hang);
            if (ModelState.IsValid)
            {

                try
                {

                    Edit.MaNV = donHang.MaNV;
                    _context.Update(Edit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!ChatLieuExists(Edit.ID_QuocGia))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Edit);
        }

        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.DonHang == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .FirstOrDefaultAsync(m => m.ID_Don_Hang == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.DonHang == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DonHang'  is null.");
            }
            var donHang = await _context.DonHang.FindAsync(id);
            if (donHang != null)
            {
                _context.DonHang.Remove(donHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatLieuExists(Guid id)
        {
            return (_context.DonHang?.Any(e => e.ID_Don_Hang == id)).GetValueOrDefault();
        }
    }
}
