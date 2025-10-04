namespace EFCoreCommon.Model
{
    public class MissionCitizen
    {
        public int MissionId { get; set; }
        public int CitizenId { get; set; }

        // Navigation properties
        public Mission Mission { get; set; } = null!;
        public Citizen Citizen { get; set; } = null!;
    }
}
