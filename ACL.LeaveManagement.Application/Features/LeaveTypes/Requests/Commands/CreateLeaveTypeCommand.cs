using ACL.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace ACL.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<int>
    {
        public CreateLeaveTypeDto LeaveTypeDto { get; set; }
    }
}
