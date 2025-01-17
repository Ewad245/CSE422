using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab2.Data;
using Lab2.Models;

namespace Lab2.Controllers
{
    public class DeviceController : Controller
    {
        private readonly DBContext _context;

        public DeviceController(DBContext context)
        {
            _context = context;
        }

        // GET: Admin/Device
        public async Task<IActionResult> Index(string searchString, int? categoryId, int? statusId)
        {
            var viewModel = new DeviceListViewModel
            {
                Categories = await _context.DeviceCategories.ToListAsync(),
                Statuses = await _context.DeviceStatuses.ToListAsync(),
                SearchString = searchString,
                SelectedCategoryId = categoryId,
                SelectedStatusId = statusId
            };

            var devices = _context.Devices
                .Include(d => d.Category)
                .Include(d => d.Status)
                .AsQueryable();

            // Apply search filter
            if (!string.IsNullOrEmpty(searchString))
            {
                devices = devices.Where(d => 
                    d.DeviceName.Contains(searchString) || 
                    d.DeviceCode.Contains(searchString));
            }

            // Apply category filter
            if (categoryId.HasValue)
            {
                devices = devices.Where(d => d.CategoryId == categoryId);
            }

            // Apply status filter
            if (statusId.HasValue)
            {
                devices = devices.Where(d => d.StatusId == statusId);
            }

            viewModel.Devices = await devices.ToListAsync();
            return View(viewModel);
        }

        // GET: Admin/Device/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _context.DeviceCategories.ToListAsync(), "CategoryId", "CategoryName");
            ViewData["StatusId"] = new SelectList(await _context.DeviceStatuses.ToListAsync(), "StatusId", "StatusName");
            return View();
        }

        // POST: Admin/Device/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceName,DeviceCode,CategoryId,StatusId")] Device device)
        {
            if (ModelState.IsValid)
            {
                device.DateOfEntry = DateTime.UtcNow;
                _context.Add(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _context.DeviceCategories.ToListAsync(), "CategoryId", "CategoryName", device.CategoryId);
            ViewData["StatusId"] = new SelectList(await _context.DeviceStatuses.ToListAsync(), "StatusId", "StatusName", device.StatusId);
            return View(device);
        }

        // GET: Admin/Device/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _context.DeviceCategories.ToListAsync(), "CategoryId", "CategoryName", device.CategoryId);
            ViewData["StatusId"] = new SelectList(await _context.DeviceStatuses.ToListAsync(), "StatusId", "StatusName", device.StatusId);
            return View(device);
        }

        // POST: Admin/Device/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeviceId,DeviceName,DeviceCode,CategoryId,StatusId,DateOfEntry")] Device device)
        {
            if (id != device.DeviceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceExists(device.DeviceId))
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
            ViewData["CategoryId"] = new SelectList(await _context.DeviceCategories.ToListAsync(), "CategoryId", "CategoryName", device.CategoryId);
            ViewData["StatusId"] = new SelectList(await _context.DeviceStatuses.ToListAsync(), "StatusId", "StatusName", device.StatusId);
            return View(device);
        }

        // GET: Admin/Device/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Devices
                .Include(d => d.Category)
                .Include(d => d.Status)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Admin/Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = await _context.Devices
                .Include(d => d.DeviceAssignments)
                .FirstOrDefaultAsync(d => d.DeviceId == id);
                
            if (device == null)
            {
                return NotFound();
            }

            // Check if device has any active assignments
            if (device.DeviceAssignments.Any(da => da.ReturnDate == null))
            {
                ModelState.AddModelError(string.Empty, "Cannot delete device that is currently assigned to a user.");
                return View(device);
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.DeviceId == id);
        }
    }
}
