namespace EFCoreCommon.Model
{
    public class RequestCitizen : BaseEntity
    {
        public int CitizenId { get; set; }
        public Citizen Citizen { get; set; } = null!;

        public int RequestId { get; set; }
        public Request Request { get; set; } = null!;

    }
}
