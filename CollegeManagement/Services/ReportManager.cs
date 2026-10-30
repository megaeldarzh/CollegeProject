namespace CollegeManagement.Services;

public class ReportManager
{
    protected internal string GenerateReport(string title, IEnumerable<string> lines)
    {
        return $"{title}{Environment.NewLine}{string.Join(Environment.NewLine, lines)}";
    }

    public string CreateReport(string title, IEnumerable<string> lines) => GenerateReport(title, lines);
}
