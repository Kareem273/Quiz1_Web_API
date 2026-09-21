namespace Quiz1.Dto.EnrollmentDto
{
    public class CreateEnrollmentDto
    {
        public int StudentId { get; set; }

        public int SubjecttId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public decimal Grade { get; set; }
    }
}
