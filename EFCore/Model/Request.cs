using EFCoreCommon.EFConstants;

namespace EFCoreCommon.Model
{
    public class Request : BaseEntity
    {

        public string Title { get; set; } = null!;

        public string Reason { get; set; } = null!;
        public DateTime? DateRequest { get; set; }

        public RequestType Type { get; set; }

        public int RequestUnitId { get; set; }
        public Unit RequestUnit { get; set; } = null!;

        public int ReceiveUnitId { get; set; }
        public Unit ReceiveUnit { get; set; } = null!;

        public ICollection<RequestCitizen> RequestCitizens { get; set; } = new List<RequestCitizen>();
    }
    
}
