using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFramework_MVC.Models;

namespace EntityFramework_MVC.Controllers
{
    public class NhanViensController : Controller
    {
        private readonly QuanLiNhanVienContext _context;

        public NhanViensController(QuanLiNhanVienContext context)
        {
            _context = context;
        }

        // GET: NhanViens
        public async Task<IActionResult> Index()
        {
            var quanLiNhanVienContext = _context.NhanViens.Include(n => n.IdNvNavigation);
            return View(await quanLiNhanVienContext.ToListAsync());
        }

        // GET: NhanViens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .Include(n => n.IdNvNavigation)
                .FirstOrDefaultAsync(m => m.MaNv_145 == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public IActionResult Create()
        {
            ViewData["IdNv_145"] = new SelectList(_context.LoaiNhanViens, "IdNv_145", "LoaiNv_145");
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNv_145,MaNv_145,TenNv_145,NgaySinh_145,GioiTinh_145,NgayVaoCoQuan_145,SoCmnd_145,HeSoLuong_145")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNv_145"] = new SelectList(_context.LoaiNhanViens, "IdNv_145", "LoaiNv_145", nhanVien.IdNv_145);
            return View(nhanVien);
        }

        // GET: NhanViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            ViewData["IdNv_145"] = new SelectList(_context.LoaiNhanViens, "IdNv_145", "LoaiNv_145", nhanVien.IdNv_145);
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNv_145,MaNv_145,TenNv_145,NgaySinh_145,GioiTinh_145,NgayVaoCoQuan_145,SoCmnd_145,HeSoLuong_145")] NhanVien nhanVien)
        {
            if (id != nhanVien.MaNv_145)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.IdNv_145))
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
            ViewData["IdNv_145"] = new SelectList(_context.LoaiNhanViens, "IdNv_145", "LoaiNv_145", nhanVien.IdNv_145);
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .Include(n => n.IdNvNavigation)
                .FirstOrDefaultAsync(m => m.MaNv_145 == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanVien = await _context.NhanViens.FindAsync(id);
            _context.NhanViens.Remove(nhanVien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(int id)
        {
            return _context.NhanViens.Any(e => e.MaNv_145 == id);
        }
    }
}
