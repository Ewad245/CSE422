namespace Lab2.Models;

// View Models for search and filtering
public class DeviceSearchViewModel
{
    public string? SearchTerm { get; set; }
    public int? CategoryId { get; set; }
    public int? StatusId { get; set; }
}