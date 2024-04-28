namespace HomeworkDeliveryAPI.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonCode { get; set; }
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        public List<Assignment> Assignments { get; set; }
    }
}
