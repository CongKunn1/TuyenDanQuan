namespace EFCoreCommon.Model
{
    public class RewardApproval : BaseEntity
    {
        public int ApprovalId { get; set; }
        public int ProposalId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime DecisionDate { get; set; }
        public string? Comments { get; set; }
        public RewardProposal Proposal { get; set; } = null!;
        public Citizen ApprovedBy { get; set; } = null!;
    }

}