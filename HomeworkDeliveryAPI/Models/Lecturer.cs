namespace HomeworkDeliveryAPI.Models
{
    public class Lecturer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } // Öğretmenin adı
        public string LastName { get; set; } // Öğretmenin soyadı
        public string Email { get; set; } // Öğretmenin e-posta adresi
        public string PhoneNumber { get; set; } // Öğretmenin telefon numarası
        public List<Lesson> Lessons { get; set; }

    }
}
