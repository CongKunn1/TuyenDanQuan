namespace TuyenDanQuan.Models
{
    public class CitizenDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? IdentificationNumber { get; set; }
        public int? Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
    }

}
