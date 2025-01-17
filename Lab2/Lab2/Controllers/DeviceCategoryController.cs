using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab2.Models;
using Lab2.Data;

namespace Lab2.Controllers
{
    public class DeviceCategoryController : Controller
    {
        private readonly DBContext _context;

        public DeviceCategoryController(DBContext context)
        {
            _context = context;
        }

        // GET: Admin/DeviceCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeviceCategories.Include(c => c.Devices).ToListAsync());
        }

        // GET: Admin/DeviceCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/DeviceCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryName")] DeviceCategory deviceCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deviceCategory);
        }

        // GET: Admin/DeviceCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceCategory = await _context.DeviceCategories.FindAsync(id);
            if (deviceCategory == null)
            {
                return NotFound();
            }
            return View(deviceCategory);
        }

        // POST: Admin/DeviceCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName")] DeviceCategory deviceCategory)
        {
            if (id != deviceCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceCategoryExists(deviceCategory.CategoryId))
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
            return View(deviceCategory);
        }

        // GET: Admin/DeviceCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceCategory = await _context.DeviceCategories
                .Include(c => c.Devices)
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (deviceCategory == null)
            {
                return NotFound();
            }

            return View(deviceCategory);
        }

        // POST: Admin/DeviceCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deviceCategory = await _context.DeviceCategories.FindAsync(id);
            if (deviceCategory == null)
            {
                return NotFound();
            }

            // Check if category has any devices
            if (await _context.Devices.AnyAsync(d => d.CategoryId == id))
            {
                ModelState.AddModelError(string.Empty, "Cannot delete category that has devices assigned to it.");
                return View(deviceCategory);
            }

            _context.DeviceCategories.Remove(deviceCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceCategoryExists(int id)
        {
            return _context.DeviceCategories.Any(e => e.CategoryId == id);
        }
    }
}
