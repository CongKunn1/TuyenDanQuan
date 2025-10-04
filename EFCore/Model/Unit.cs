using EFCoreCommon.EFConstants;

namespace EFCoreCommon.Model
{
    public class Unit : BaseEntity
    {

        public string Code { get; set; }

        public string UnitName { get; set; }

        public UnitLevel Type { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ICollection<Mission> Missions { get; set; } = new List<Mission>();
        public ICollection<Citizen> Citizens { get; set; } = new List<Citizen>();

    }



}