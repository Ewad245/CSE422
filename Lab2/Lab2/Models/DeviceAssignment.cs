using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models;

public class DeviceAssignment
{
    [Key]
    public int AssignmentId { get; set; }

    [Required(ErrorMessage = "Please select a device")]
    [Display(Name = "Device")]
    public int DeviceId { get; set; }

    [Required(ErrorMessage = "Please select a user")]
    [Display(Name = "User")]
    public int UserId { get; set; }

    [Required]
    [Display(Name = "Assignment Date")]
    public DateTime AssignmentDate { get; set; } = DateTime.UtcNow;

    [Display(Name = "Return Date")]
    public DateTime? ReturnDate { get; set; }

    // Navigation properties
    [ForeignKey("DeviceId")]
    public virtual Device? Device { get; set; }

    [ForeignKey("UserId")]
    public virtual User? User { get; set; }
}