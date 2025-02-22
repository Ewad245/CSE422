public interface IReportService
{
    Report GenerateReaderReport(string readerId);
    Report GenerateOverallReport();
}

public class Report
{
    public string Title { get; set; }
    public DateTime GeneratedAt { get; set; }
    public string Content { get; set; }
}

public class Result
{
    public bool Success { get; set; }
    public string Message { get; set; }
} 