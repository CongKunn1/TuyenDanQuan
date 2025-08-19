namespace TuyenDanQuan.Models
{
    public class CitizenFilterDto
    {
        public string FullName { get; set; }
        public string? IdentificationNumber { get; set; }
        public int? Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
