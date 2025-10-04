namespace TuyenDanQuan.Models
{
    public class CreateMissionDto
    {
        public int UnitId { get; set; }       
        public int CitizenId { get; set; }   

        public string DecisionNumber { get; set; } = null!;
        public DateTime DecisionDate { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }
}
