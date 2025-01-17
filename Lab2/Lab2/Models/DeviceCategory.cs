using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class DeviceCategory
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(100)]
    public string CategoryName { get; set; } = string.Empty;

    // Navigation property
    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}