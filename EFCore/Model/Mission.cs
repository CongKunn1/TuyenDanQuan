namespace EFCoreCommon.Model
{
    public class Mission : BaseEntity
    {
        public int TaskId { get; set; }
        public int UnitId { get; set; }

        public string DecisionNumber { get; set; } = null!;  
        public DateTime DecisionDate { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; }

         public int CitizenId { get; set; }

        public string Status { get; set; } = "NotStarted"; // NotStarted/InProgress/Completed

        public Unit Unit { get; set; } = null!;
        public Citizen Citizen { get; set; } = null!;
    }

}
