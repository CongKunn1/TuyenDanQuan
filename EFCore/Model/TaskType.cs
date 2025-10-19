using EFCoreCommon.Model;

public class TaskType : BaseEntity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public ICollection<Mission> Missions { get; set; } = new List<Mission>();
}
