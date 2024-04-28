namespace HomeworkDeliveryAPI.Dtos
{
    public class HomeWorkDto
    {
        public int Id { get; set; } // Ödevin kimlik numarası

        public string Title { get; set; } // Ödevin başlığı veya adı
        public string Description { get; set; } // Ödevin açıklaması
        public DateTime StartDate { get; set; } // Ödevin başlangıç tarihi
        public DateTime Deadline { get; set; } // Ödevin son teslim tarihi
        public bool Status { get; set; } // Ödevin durumu: tamamlandı (true) veya tamamlanmadı (false)
        public int LessonId { get; set; }
    }
}
