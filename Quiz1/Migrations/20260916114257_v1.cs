using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Quiz1.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classroom",
                columns: new[] { "ClassroomId", "Capacity", "Grade", "Name" },
                values: new object[,]
                {
                    { 1, 30, 1, "Grade 1 - A" },
                    { 2, 30, 2, "Grade 2 - A" },
                    { 3, 35, 3, "Grade 3 - A" },
                    { 4, 35, 4, "Grade 4 - A" },
                    { 5, 40, 5, "Grade 5 - A" },
                    { 6, 40, 6, "Grade 6 - A" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Department of Mathematics", "Mathematics" },
                    { 2, "Department of Science", "Science" },
                    { 3, "Department of English Language", "English" },
                    { 4, "Department of Arabic Language", "Arabic" },
                    { 5, "Department of Computer Science", "Computer Science" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "ClassroomId", "DOF", "Email", "Firstname", "Lastname", "Phone" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2018, 3, 15), "ali.hassan@student.com", "Ali", "Hassan", "01112345678" },
                    { 2, 1, new DateOnly(2018, 7, 20), "omar.ahmed@student.com", "Omar", "Ahmed", "01123456789" },
                    { 3, 2, new DateOnly(2017, 5, 10), "youssef.mohamed@student.com", "Youssef", "Mohamed", "01134567890" },
                    { 4, 2, new DateOnly(2017, 9, 25), "adam.mahmoud@student.com", "Adam", "Mahmoud", "01145678901" },
                    { 5, 3, new DateOnly(2016, 2, 5), "mariam.ali@student.com", "Mariam", "Ali", "01156789012" },
                    { 6, 3, new DateOnly(2016, 11, 12), "nour.ibrahim@student.com", "Nour", "Ibrahim", "01167890123" },
                    { 7, 4, new DateOnly(2015, 6, 18), "khaled.sayed@student.com", "Khaled", "Sayed", "01178901234" },
                    { 8, 4, new DateOnly(2015, 10, 8), "salma.hassan@student.com", "Salma", "Hassan", "01189012345" },
                    { 9, 5, new DateOnly(2014, 4, 22), "ziad.mostafa@student.com", "Ziad", "Mostafa", "01190123456" },
                    { 10, 5, new DateOnly(2014, 12, 3), "lina.adel@student.com", "Lina", "Adel", "01101234567" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "TeacherId", "DepartmentId", "EmailAddress", "FirstName", "LastName", "Phone", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "ahmed.hassan@school.com", "Ahmed", "Hassan", "01012345678", 15000m },
                    { 2, 1, "mohamed.ali@school.com", "Mohamed", "Ali", "01023456789", 14500m },
                    { 3, 2, "sara.ibrahim@school.com", "Sara", "Ibrahim", "01034567890", 15500m },
                    { 4, 3, "omar.mahmoud@school.com", "Omar", "Mahmoud", "01045678901", 15000m },
                    { 5, 4, "mariam.ahmed@school.com", "Mariam", "Ahmed", "01056789012", 16000m },
                    { 6, 5, "youssef.khaled@school.com", "Youssef", "Khaled", "01067890123", 17000m }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "SubjectId", "Description", "Grade", "Name", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Basic mathematics and problem solving", "45", "Mathematics", 1 },
                    { 2, "Advanced mathematical concepts", "45", "Advanced Mathematics", 2 },
                    { 3, "Basic science and natural phenomena", "45", "Science", 3 },
                    { 4, "English grammar, reading and writing", "56", "English Language", 4 },
                    { 5, "Arabic grammar, reading and writing", "80", "Arabic Language", 5 },
                    { 6, "Programming and computer science fundamentals", "70", "Computer Science", 6 }
                });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "EnrollmentId", "EnrollmentDate", "Grade", "StudentId", "SubjecttId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85m, 1, 1 },
                    { 2, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, 2, 1 },
                    { 3, new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 88m, 3, 2 },
                    { 4, new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 76m, 4, 2 },
                    { 5, new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 92m, 5, 3 },
                    { 6, new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 87m, 6, 3 },
                    { 7, new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 95m, 7, 4 },
                    { 8, new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 89m, 8, 4 },
                    { 9, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 91m, 9, 5 },
                    { 10, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 94m, 10, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "ClassroomId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "TeacherId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "ClassroomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "ClassroomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "ClassroomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "ClassroomId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "ClassroomId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DepartmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "TeacherId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "TeacherId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "TeacherId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "TeacherId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "TeacherId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DepartmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DepartmentId",
                keyValue: 4);
        }
    }
}
