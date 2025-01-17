using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class User
{
    public int UserId { get; set; }

    [Required]
    [StringLength(200)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    // Navigation property
    public virtual ICollection<DeviceAssignment> DeviceAssignments { get; set; } = new List<DeviceAssignment>();
}