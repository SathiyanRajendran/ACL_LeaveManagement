using ACL.LeaveManagement.Application.DTOs.Common;

namespace ACL.LeaveManagement.Application.DTOs.LeaveAllocation;

public class UpdateLeaveAllocationDto : BaseDto
{
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}
