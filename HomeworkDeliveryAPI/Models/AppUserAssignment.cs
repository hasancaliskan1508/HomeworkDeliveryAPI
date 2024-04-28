namespace HomeworkDeliveryAPI.Models
{
    public class AppUserAssignment
    {
        public int Id { get; set; }
        public string AppUserNumber { get; set; }
        public AppUser AppUser { get; set; }
        public int AssingnmentId { get; set; }
        public Assignment Assignment { get; set; }

    }
}
