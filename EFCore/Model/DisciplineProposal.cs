namespace EFCoreCommon.Model
{
    public class DisciplineProposal : BaseEntity
    {
        public int DisciplineProposalId { get; set; }

        public int UnitId { get; set; }
        public int CitizenId { get; set; }

        public string Reason { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? Notes { get; set; }

        public Unit Unit { get; set; } = null!;
        public Citizen Citizen { get; set; } = null!;
        public ICollection<DisciplineApproval> DisciplineApprovals { get; set; } = new List<DisciplineApproval>();
    }


}