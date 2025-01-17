using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models;

public class Device
{
    [Key]
    public int DeviceId { get; set; }

    [Required(ErrorMessage = "Device name is required")]
    [StringLength(200)]
    [Display(Name = "Device Name")]
    public string DeviceName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Device code is required")]
    [StringLength(100)]
    [Display(Name = "Device Code")]
    public string DeviceCode { get; set; } = string.Empty;

    [Required(ErrorMessage = "Category is required")]
    [Display(Name = "Category")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Status is required")]
    [Display(Name = "Status")]
    public int StatusId { get; set; }

    public DateTime DateOfEntry { get; set; } = DateTime.UtcNow;

    // Navigation properties
    [ForeignKey("CategoryId")]
    public virtual DeviceCategory? Category { get; set; }

    [ForeignKey("StatusId")]
    public virtual DeviceStatus? Status { get; set; }

    public virtual ICollection<DeviceAssignment> DeviceAssignments { get; set; } = new List<DeviceAssignment>();
}