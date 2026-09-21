namespace Quiz1.Dto.StudentDto
{
    public class CreateStudentDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }


        public string Phone { get; set; }



        public DateOnly DOF { get; set; }

        public int ClassroomId { get; set; }
    }
}
