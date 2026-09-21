using System.Runtime.Intrinsics.Arm;
using Microsoft.EntityFrameworkCore;
using Quiz1.Models;

namespace Quiz1.Data
{
    public class AppDbContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=School;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False  ");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>()
                .HasMany(d=>d.Teachers)
                .WithOne(t=>t.Department)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Teacher>()
                .HasMany(t=>t.Subjects)
                .WithOne(s=>s.Teacher)
                .HasForeignKey(t=>t.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Classroom>()
                .HasMany(c=>c.Students)
                .WithOne(s=>s.Classroom)
                .HasForeignKey(c=>c.ClassroomId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e=>e.Student)
                .WithMany(e=>e.Enrollments)
                .HasForeignKey(e=>e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e=>e.Subject)
                .WithMany(e=>e.Enrollments)
                .HasForeignKey(e=>e.SubjecttId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>().HasIndex(e => new { e.StudentId, e.SubjecttId }).IsUnique();

            modelBuilder.Entity<Student>().HasIndex(T=>T.Email).IsUnique();
            modelBuilder.Entity<Teacher>().HasIndex(T=>T.EmailAddress).IsUnique();

            modelBuilder.Entity<Department>().HasData(
     new Department
     {
         DepartmentId = 1,
         Name = "Mathematics",
         Description = "Department of Mathematics"
     },
     new Department
     {
         DepartmentId = 2,
         Name = "Science",
         Description = "Department of Science"
     },
     new Department
     {
         DepartmentId = 3,
         Name = "English",
         Description = "Department of English Language"
     },
     new Department
     {
         DepartmentId = 4,
         Name = "Arabic",
         Description = "Department of Arabic Language"
     },
     new Department
     {
         DepartmentId = 5,
         Name = "Computer Science",
         Description = "Department of Computer Science"
     }
 );

            modelBuilder.Entity<Classroom>().HasData(
                new Classroom
                {
                    ClassroomId = 1,
                    Name = "Grade 1 - A",
                    Grade = 1,
                    Capacity = 30
                },
                new Classroom
                {
                    ClassroomId = 2,
                    Name = "Grade 2 - A",
                    Grade = 2,
                    Capacity = 30
                },
                new Classroom
                {
                    ClassroomId = 3,
                    Name = "Grade 3 - A",
                    Grade = 3,
                    Capacity = 35
                },
                new Classroom
                {
                    ClassroomId = 4,
                    Name = "Grade 4 - A",
                    Grade = 4,
                    Capacity = 35
                },
                new Classroom
                {
                    ClassroomId = 5,
                    Name = "Grade 5 - A",
                    Grade = 5,
                    Capacity = 40
                },
                new Classroom
                {
                    ClassroomId = 6,
                    Name = "Grade 6 - A",
                    Grade = 6,
                    Capacity = 40
                }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    TeacherId = 1,
                    FirstName = "Ahmed",
                    LastName = "Hassan",
                    EmailAddress = "ahmed.hassan@school.com",
                    Phone = "01012345678",
                    Salary = 15000m,
                    DepartmentId = 1
                },
                new Teacher
                {
                    TeacherId = 2,
                    FirstName = "Mohamed",
                    LastName = "Ali",
                    EmailAddress = "mohamed.ali@school.com",
                    Phone = "01023456789",
                    Salary = 14500m,
                    DepartmentId = 1
                },
                new Teacher
                {
                    TeacherId = 3,
                    FirstName = "Sara",
                    LastName = "Ibrahim",
                    EmailAddress = "sara.ibrahim@school.com",
                    Phone = "01034567890",
                    Salary = 15500m,
                    DepartmentId = 2
                },
                new Teacher
                {
                    TeacherId = 4,
                    FirstName = "Omar",
                    LastName = "Mahmoud",
                    EmailAddress = "omar.mahmoud@school.com",
                    Phone = "01045678901",
                    Salary = 15000m,
                    DepartmentId = 3
                },
                new Teacher
                {
                    TeacherId = 5,
                    FirstName = "Mariam",
                    LastName = "Ahmed",
                    EmailAddress = "mariam.ahmed@school.com",
                    Phone = "01056789012",
                    Salary = 16000m,
                    DepartmentId = 4
                },
                new Teacher
                {
                    TeacherId = 6,
                    FirstName = "Youssef",
                    LastName = "Khaled",
                    EmailAddress = "youssef.khaled@school.com",
                    Phone = "01067890123",
                    Salary = 17000m,
                    DepartmentId = 5
                }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    Firstname = "Ali",
                    Lastname = "Hassan",
                    Email = "ali.hassan@student.com",
                    Phone = "01112345678",
                    DOF = new DateOnly(2018, 3, 15),
                    ClassroomId = 1
                },
                new Student
                {
                    StudentId = 2,
                    Firstname = "Omar",
                    Lastname = "Ahmed",
                    Email = "omar.ahmed@student.com",
                    Phone = "01123456789",
                    DOF = new DateOnly(2018, 7, 20),
                    ClassroomId = 1
                },
                new Student
                {
                    StudentId = 3,
                    Firstname = "Youssef",
                    Lastname = "Mohamed",
                    Email = "youssef.mohamed@student.com",
                    Phone = "01134567890",
                    DOF = new DateOnly(2017, 5, 10),
                    ClassroomId = 2
                },
                new Student
                {
                    StudentId = 4,
                    Firstname = "Adam",
                    Lastname = "Mahmoud",
                    Email = "adam.mahmoud@student.com",
                    Phone = "01145678901",
                    DOF = new DateOnly(2017, 9, 25),
                    ClassroomId = 2
                },
                new Student
                {
                    StudentId = 5,
                    Firstname = "Mariam",
                    Lastname = "Ali",
                    Email = "mariam.ali@student.com",
                    Phone = "01156789012",
                    DOF = new DateOnly(2016, 2, 5),
                    ClassroomId = 3
                },
                new Student
                {
                    StudentId = 6,
                    Firstname = "Nour",
                    Lastname = "Ibrahim",
                    Email = "nour.ibrahim@student.com",
                    Phone = "01167890123",
                    DOF = new DateOnly(2016, 11, 12),
                    ClassroomId = 3
                },
                new Student
                {
                    StudentId = 7,
                    Firstname = "Khaled",
                    Lastname = "Sayed",
                    Email = "khaled.sayed@student.com",
                    Phone = "01178901234",
                    DOF = new DateOnly(2015, 6, 18),
                    ClassroomId = 4
                },
                new Student
                {
                    StudentId = 8,
                    Firstname = "Salma",
                    Lastname = "Hassan",
                    Email = "salma.hassan@student.com",
                    Phone = "01189012345",
                    DOF = new DateOnly(2015, 10, 8),
                    ClassroomId = 4
                },
                new Student
                {
                    StudentId = 9,
                    Firstname = "Ziad",
                    Lastname = "Mostafa",
                    Email = "ziad.mostafa@student.com",
                    Phone = "01190123456",
                    DOF = new DateOnly(2014, 4, 22),
                    ClassroomId = 5
                },
                new Student
                {
                    StudentId = 10,
                    Firstname = "Lina",
                    Lastname = "Adel",
                    Email = "lina.adel@student.com",
                    Phone = "01101234567",
                    DOF = new DateOnly(2014, 12, 3),
                    ClassroomId = 5
                }
            );

            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    SubjectId = 1,
                    Name = "Mathematics",
                    Description = "Basic mathematics and problem solving",
                    Grade = "45",
                    TeacherId = 1
                },
                new Subject
                {
                    SubjectId = 2,
                    Name = "Advanced Mathematics",
                    Description = "Advanced mathematical concepts",
                    Grade = "45",
                    TeacherId = 2
                },
                new Subject
                {
                    SubjectId = 3,
                    Name = "Science",
                    Description = "Basic science and natural phenomena",
                    Grade = "45",
                    TeacherId = 3
                },
                new Subject
                {
                    SubjectId = 4,
                    Name = "English Language",
                    Description = "English grammar, reading and writing",
                    Grade = "56",
                    TeacherId = 4
                },
                new Subject
                {
                    SubjectId = 5,
                    Name = "Arabic Language",
                    Description = "Arabic grammar, reading and writing",
                    Grade = "80",
                    TeacherId = 5
                },
                new Subject
                {
                    SubjectId = 6,
                    Name = "Computer Science",
                    Description = "Programming and computer science fundamentals",
                    Grade = "70",
                    TeacherId = 6
                }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    EnrollmentId = 1,
                    StudentId = 1,
                    SubjecttId = 1,
                    EnrollmentDate = new DateTime(2025, 9, 1),
                    Grade = 85
                },
                new Enrollment
                {
                    EnrollmentId = 2,
                    StudentId = 2,
                    SubjecttId = 1,
                    EnrollmentDate = new DateTime(2025, 9, 1),
                    Grade = 90
                },
                new Enrollment
                {
                    EnrollmentId = 3,
                    StudentId = 3,
                    SubjecttId = 2,
                    EnrollmentDate = new DateTime(2025, 9, 2),
                    Grade = 88
                },
                new Enrollment
                {
                    EnrollmentId = 4,
                    StudentId = 4,
                    SubjecttId = 2,
                    EnrollmentDate = new DateTime(2025, 9, 2),
                    Grade = 76
                },
                new Enrollment
                {
                    EnrollmentId = 5,
                    StudentId = 5,
                    SubjecttId = 3,
                    EnrollmentDate = new DateTime(2025, 9, 3),
                    Grade = 92
                },
                new Enrollment
                {
                    EnrollmentId = 6,
                    StudentId = 6,
                    SubjecttId = 3,
                    EnrollmentDate = new DateTime(2025, 9, 3),
                    Grade = 87
                },
                new Enrollment
                {
                    EnrollmentId = 7,
                    StudentId = 7,
                    SubjecttId = 4,
                    EnrollmentDate = new DateTime(2025, 9, 4),
                    Grade = 95
                },
                new Enrollment
                {
                    EnrollmentId = 8,
                    StudentId = 8,
                    SubjecttId = 4,
                    EnrollmentDate = new DateTime(2025, 9, 4),
                    Grade = 89
                },
                new Enrollment
                {
                    EnrollmentId = 9,
                    StudentId = 9,
                    SubjecttId = 5,
                    EnrollmentDate = new DateTime(2025, 9, 5),
                    Grade = 91
                },
                new Enrollment
                {
                    EnrollmentId = 10,
                    StudentId = 10,
                    SubjecttId = 5,
                    EnrollmentDate = new DateTime(2025, 9, 5),
                    Grade = 94
                }
            );



            base.OnModelCreating(modelBuilder);
        }
    }
}
