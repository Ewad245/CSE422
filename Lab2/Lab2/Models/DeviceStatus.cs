using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class DeviceStatus
{
    [Key]
    public int StatusId { get; set; }

    [Required]
    [StringLength(50)]
    public string StatusName { get; set; } = string.Empty;

    // Navigation property
    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}