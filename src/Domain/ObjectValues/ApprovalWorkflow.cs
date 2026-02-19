using src.Domain.Interface;

namespace src.Domain.ObjectValues;

public class ApprovalWorkflow : IPrototype<ApprovalWorkflow>
{
    public List<string> Approvers { get; set; }
    public int RequiredApprovals { get; set; }
    public int TimeoutDays { get; set; }

    public ApprovalWorkflow()
    {
        Approvers = new List<string>();
    }

    public ApprovalWorkflow Clone()
    {
        return new ApprovalWorkflow
        {
            RequiredApprovals = RequiredApprovals,
            TimeoutDays = TimeoutDays,
            Approvers = new List<string>(Approvers)
        };
    }
}