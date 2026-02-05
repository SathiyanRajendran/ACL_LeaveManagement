using MediatR;

namespace ACL.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;

public class DeleteLeaveAllocationCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
