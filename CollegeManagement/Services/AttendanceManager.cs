namespace CollegeManagement.Services;

public class AttendanceManager
{
    private readonly Dictionary<int, List<bool>> _attendance = new();

    public void AddAttendance(int studentId, bool present)
    {
        if (!_attendance.TryGetValue(studentId, out var records))
            _attendance[studentId] = records = new List<bool>();
        records.Add(present);
    }

    public bool UpdateAttendance(int studentId, int index, bool present)
    {
        return _attendance.TryGetValue(studentId, out var records) && index >= 0 && index < records.Count && SetValue(records, index, present);
    }

    public (int Total, int Present, double Percentage) GetStatistics(int studentId)
    {
        if (!_attendance.TryGetValue(studentId, out var records) || records.Count == 0) return (0, 0, 0);
        var present = records.Count(item => item);
        return (records.Count, present, Math.Round(present * 100d / records.Count, 2));
    }

    private static bool SetValue(List<bool> records, int index, bool value)
    {
        records[index] = value;
        return true;
    }
}
