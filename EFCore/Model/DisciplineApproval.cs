namespace EFCoreCommon.Model
{
    public class DisciplineApproval : BaseEntity
    {
        public int DisciplineProposalId { get; set; }

        public DisciplineDecision Decision { get; set; }   
        public DateTime DecisionDate { get; set; }
        public string? Comments { get; set; }

        public DisciplineProposal Proposal { get; set; } = null!;
        public Citizen ApprovedBy { get; set; } = null!;
    }

}