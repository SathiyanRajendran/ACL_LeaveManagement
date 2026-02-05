using ACL.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;
using System.Collections.Generic;

namespace ACL.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {
    }
}
