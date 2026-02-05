using ACL.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace ACL.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;

public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
{
}
