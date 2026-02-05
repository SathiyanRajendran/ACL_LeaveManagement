using ACL.LeaveManagement.Application.DTOs.Common;
using ACL.LeaveManagement.Application.DTOs.LeaveType;

namespace ACL.LeaveManagement.Application.DTOs.LeaveAllocation;

public class LeaveAllocationDto : BaseDto
{
    public int NumberOfDays { get; set; }
    public LeaveTypeDto? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
}
