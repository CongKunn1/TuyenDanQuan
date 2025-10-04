namespace EFCoreCommon.Model
{
    public class Mission : BaseEntity
    {
        public int TaskTypeId { get; set; }         
        public TaskType TaskType { get; set; } = null!;

        public int UnitId { get; set; }

        public string DecisionNumber { get; set; } = null!;  
        public DateTime DecisionDate { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; }


        public string Status { get; set; } = "NotStarted"; 

        public Unit Unit { get; set; } = null!;
        public ICollection<MissionCitizen> MissionCitizens { get; set; } = new List<MissionCitizen>();

    }

}
