using CollegeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(CollegeDbContext db)
    {
        await db.Database.EnsureCreatedAsync();

        if (await db.Students.AnyAsync()) return;

        var firstStudent = new Student("Иван", "Петров", 18, "ИС-21");
        var secondStudent = new Student("Анна", "Смирнова", 19, "ИС-21");
        var teacher = new Teacher("Ольга", "Иванова", 42, "Программирование", 15);
        var group = new Group("ИС-21", 2);
        var subject = new Subject("Программирование", 144);
        subject.AssignTeacher(teacher);

        db.AddRange(firstStudent, secondStudent, teacher, group, subject);
        await db.SaveChangesAsync();
    }
}
