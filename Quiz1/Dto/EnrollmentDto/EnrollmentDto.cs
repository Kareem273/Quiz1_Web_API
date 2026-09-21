namespace Quiz1.Dto.EnrollmentDto
{
    public class EnrollmentDto
    {
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public int SubjecttId { get; set; }

        public string SubjectName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public decimal Grade { get; set; }
    }
}
