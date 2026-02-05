using ACL.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace ACL.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;

public class CreateLeaveAllocationCommand : IRequest<int>
{
    public CreateLeaveAllocationDto CreateLeaveAllocationDto { get; set; }
}
