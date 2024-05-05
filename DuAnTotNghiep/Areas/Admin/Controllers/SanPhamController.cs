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
    [Route("Admin/SanPham")]
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SanPhamController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SanPham.Include(s => s.ChatLieu).Include(s => s.HangSX).Include(s => s.KichThuoc).Include(s => s.LoaiDt).Include(s => s.LoaiSP).Include(s => s.MauSac).Include(s => s.QuocGia);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/SanPham/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.ChatLieu)
                .Include(s => s.HangSX)
                .Include(s => s.KichThuoc)
                .Include(s => s.LoaiDt)
                .Include(s => s.LoaiSP)
                .Include(s => s.MauSac)
                .Include(s => s.QuocGia)
                .FirstOrDefaultAsync(m => m.ID_Sp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: Admin/SanPham/Create
        public IActionResult Create()
        {
            ViewData["ID_ChatLieu"] = new SelectList(_context.ChatLieu, "ID_ChatLieu", "ID_ChatLieu");
            ViewData["ID_Hang"] = new SelectList(_context.HangSX, "ID_Hang", "ID_Hang");
            ViewData["ID_KichThuoc"] = new SelectList(_context.KichThuoc, "ID_KichThuoc", "ID_KichThuoc");
            ViewData["ID_LoaiDt"] = new SelectList(_context.LoaiDt, "ID_LoaiDt", "ID_LoaiDt");
            ViewData["ID_LoaiSp"] = new SelectList(_context.LoaiSP, "ID_LoaiSp", "ID_LoaiSp");
            ViewData["ID_MauSac"] = new SelectList(_context.MauSac, "ID_MauSac", "ID_MauSac");
            ViewData["ID_QuocGia"] = new SelectList(_context.QuocGia, "ID_QuocGia", "ID_QuocGia");
            return View();
        }

        // POST: Admin/SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Sp,TenSP,MoTa,SoLuong,Gia,AnhDaiDien,DanhGia,HoTenAdmin,ID_ChatLieu,ID_Hang,ID_QuocGia,ID_LoaiSp,ID_LoaiDt,ID_MauSac,ID_KichThuoc")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                sanPham.ID_Sp = Guid.NewGuid();
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_ChatLieu"] = new SelectList(_context.ChatLieu, "ID_ChatLieu", "ID_ChatLieu", sanPham.ID_ChatLieu);
            ViewData["ID_Hang"] = new SelectList(_context.HangSX, "ID_Hang", "ID_Hang", sanPham.ID_Hang);
            ViewData["ID_KichThuoc"] = new SelectList(_context.KichThuoc, "ID_KichThuoc", "ID_KichThuoc", sanPham.ID_KichThuoc);
            ViewData["ID_LoaiDt"] = new SelectList(_context.LoaiDt, "ID_LoaiDt", "ID_LoaiDt", sanPham.ID_LoaiDt);
            ViewData["ID_LoaiSp"] = new SelectList(_context.LoaiSP, "ID_LoaiSp", "ID_LoaiSp", sanPham.ID_LoaiSp);
            ViewData["ID_MauSac"] = new SelectList(_context.MauSac, "ID_MauSac", "ID_MauSac", sanPham.ID_MauSac);
            ViewData["ID_QuocGia"] = new SelectList(_context.QuocGia, "ID_QuocGia", "ID_QuocGia", sanPham.ID_QuocGia);
            return View(sanPham);
        }

        // GET: Admin/SanPham/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["ID_ChatLieu"] = new SelectList(_context.ChatLieu, "ID_ChatLieu", "ID_ChatLieu", sanPham.ID_ChatLieu);
            ViewData["ID_Hang"] = new SelectList(_context.HangSX, "ID_Hang", "ID_Hang", sanPham.ID_Hang);
            ViewData["ID_KichThuoc"] = new SelectList(_context.KichThuoc, "ID_KichThuoc", "ID_KichThuoc", sanPham.ID_KichThuoc);
            ViewData["ID_LoaiDt"] = new SelectList(_context.LoaiDt, "ID_LoaiDt", "ID_LoaiDt", sanPham.ID_LoaiDt);
            ViewData["ID_LoaiSp"] = new SelectList(_context.LoaiSP, "ID_LoaiSp", "ID_LoaiSp", sanPham.ID_LoaiSp);
            ViewData["ID_MauSac"] = new SelectList(_context.MauSac, "ID_MauSac", "ID_MauSac", sanPham.ID_MauSac);
            ViewData["ID_QuocGia"] = new SelectList(_context.QuocGia, "ID_QuocGia", "ID_QuocGia", sanPham.ID_QuocGia);
            return View(sanPham);
        }

        // POST: Admin/SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID_Sp,TenSP,MoTa,SoLuong,Gia,AnhDaiDien,DanhGia,HoTenAdmin,ID_ChatLieu,ID_Hang,ID_QuocGia,ID_LoaiSp,ID_LoaiDt,ID_MauSac,ID_KichThuoc")] SanPham sanPham)
        {
            if (id != sanPham.ID_Sp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.ID_Sp))
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
            ViewData["ID_ChatLieu"] = new SelectList(_context.ChatLieu, "ID_ChatLieu", "ID_ChatLieu", sanPham.ID_ChatLieu);
            ViewData["ID_Hang"] = new SelectList(_context.HangSX, "ID_Hang", "ID_Hang", sanPham.ID_Hang);
            ViewData["ID_KichThuoc"] = new SelectList(_context.KichThuoc, "ID_KichThuoc", "ID_KichThuoc", sanPham.ID_KichThuoc);
            ViewData["ID_LoaiDt"] = new SelectList(_context.LoaiDt, "ID_LoaiDt", "ID_LoaiDt", sanPham.ID_LoaiDt);
            ViewData["ID_LoaiSp"] = new SelectList(_context.LoaiSP, "ID_LoaiSp", "ID_LoaiSp", sanPham.ID_LoaiSp);
            ViewData["ID_MauSac"] = new SelectList(_context.MauSac, "ID_MauSac", "ID_MauSac", sanPham.ID_MauSac);
            ViewData["ID_QuocGia"] = new SelectList(_context.QuocGia, "ID_QuocGia", "ID_QuocGia", sanPham.ID_QuocGia);
            return View(sanPham);
        }

        // GET: Admin/SanPham/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.ChatLieu)
                .Include(s => s.HangSX)
                .Include(s => s.KichThuoc)
                .Include(s => s.LoaiDt)
                .Include(s => s.LoaiSP)
                .Include(s => s.MauSac)
                .Include(s => s.QuocGia)
                .FirstOrDefaultAsync(m => m.ID_Sp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.SanPham == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SanPham'  is null.");
            }
            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham != null)
            {
                _context.SanPham.Remove(sanPham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(Guid id)
        {
          return (_context.SanPham?.Any(e => e.ID_Sp == id)).GetValueOrDefault();
        }
    }
}
