using ACL.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace ACL.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;

public class UpdateLeaveAllocationCommand : IRequest<Unit>
{
    public UpdateLeaveAllocationDto UpdateLeaveAllocationDto { get; set; }
}
