using System.Collections.Generic;

namespace Lab2.Models;

public class DeviceListViewModel
{
    public IEnumerable<Device> Devices { get; set; } = new List<Device>();
    public IEnumerable<DeviceCategory> Categories { get; set; } = new List<DeviceCategory>();
    public IEnumerable<DeviceStatus> Statuses { get; set; } = new List<DeviceStatus>();
    public string? SearchString { get; set; }
    public int? SelectedCategoryId { get; set; }
    public int? SelectedStatusId { get; set; }
}