using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab2.Data;
using Lab2.Models;

namespace Lab2.Controllers
{
    public class DeviceAssignmentController : Controller
    {
        private readonly DBContext _context;

        public DeviceAssignmentController(DBContext context)
        {
            _context = context;
        }

        // GET: DeviceAssignment
        public async Task<IActionResult> Index()
        {
            var assignments = await _context.DeviceAssignments
                .Include(d => d.Device)
                .Include(d => d.User)
                .OrderByDescending(d => d.AssignmentDate)
                .ToListAsync();

            return View(assignments);
        }

        // GET: DeviceAssignment/Create
        public async Task<IActionResult> Create()
        {
            await PopulateDropDowns();
            return View();
        }

        // POST: DeviceAssignment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,UserId")] DeviceAssignment deviceAssignment)
        {
            if (ModelState.IsValid)
            {
                // Check if device is already assigned
                var existingAssignment = await _context.DeviceAssignments
                    .Where(d => d.DeviceId == deviceAssignment.DeviceId && d.ReturnDate == null)
                    .FirstOrDefaultAsync();

                if (existingAssignment != null)
                {
                    ModelState.AddModelError("DeviceId", "This device is already assigned to another user.");
                    await PopulateDropDowns();
                    return View(deviceAssignment);
                }

                deviceAssignment.AssignmentDate = DateTime.UtcNow;
                _context.Add(deviceAssignment);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Device assigned successfully.";
                return RedirectToAction(nameof(Index));
            }

            await PopulateDropDowns();
            return View(deviceAssignment);
        }

        // GET: DeviceAssignment/Return/5
        public async Task<IActionResult> Return(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceAssignment = await _context.DeviceAssignments
                .Include(d => d.Device)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);

            if (deviceAssignment == null)
            {
                return NotFound();
            }

            return View(deviceAssignment);
        }

        // POST: DeviceAssignment/Return/5
        [HttpPost, ActionName("Return")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReturnConfirmed(int id)
        {
            var deviceAssignment = await _context.DeviceAssignments.FindAsync(id);
            if (deviceAssignment == null)
            {
                return NotFound();
            }

            deviceAssignment.ReturnDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            TempData["Success"] = "Device returned successfully.";
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropDowns()
        {
            var availableDevices = await _context.Devices
                .Where(d => !_context.DeviceAssignments
                    .Where(da => da.ReturnDate == null)
                    .Select(da => da.DeviceId)
                    .Contains(d.DeviceId))
                .ToListAsync();

            ViewData["DeviceId"] = new SelectList(availableDevices, "DeviceId", "DeviceName");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName");
        }
    }
}
