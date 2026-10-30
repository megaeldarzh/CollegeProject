using CollegeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Data;

public class CollegeDbContext(DbContextOptions<CollegeDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Subject> Subjects => Set<Subject>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasKey(student => student.StudentId);
        modelBuilder.Entity<Student>().Property<string>("Name").HasField("_name").HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Student>().Property<string>("Surname").HasField("_surname").HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Student>().Property<int>("Age").HasField("_age").IsRequired();
        modelBuilder.Entity<Student>().Property(student => student.Group).HasMaxLength(20).IsRequired();
        modelBuilder.Entity<Student>().HasIndex(student => student.StudentId).IsUnique();

        modelBuilder.Entity<Teacher>().HasKey(teacher => teacher.TeacherId);
        modelBuilder.Entity<Teacher>().Property<string>("Name").HasField("_name").HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Teacher>().Property<string>("Surname").HasField("_surname").HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Teacher>().Property<string>("Subject").HasField("_subject").HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Teacher>().Property<int>("Experience").HasField("_experience").IsRequired();

        modelBuilder.Entity<Group>().HasKey(group => group.GroupId);
        modelBuilder.Entity<Group>().Property(group => group.Name).HasMaxLength(20).IsRequired();
        modelBuilder.Entity<Group>().HasIndex(group => group.Name).IsUnique();

        modelBuilder.Entity<Subject>().HasKey(subject => subject.SubjectId);
        modelBuilder.Entity<Subject>().Property<string>("Name").HasField("_name").HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Subject>().Property<int>("Hours").HasField("_hours").IsRequired();
        modelBuilder.Entity<Subject>().Ignore(subject => subject.Teacher);
        modelBuilder.Entity<Group>().Ignore(group => group.Students);
    }
}
