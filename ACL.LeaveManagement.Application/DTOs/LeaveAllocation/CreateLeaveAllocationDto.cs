using ACL.LeaveManagement.Application.DTOs.Common;

namespace ACL.LeaveManagement.Application.DTOs.LeaveAllocation;

public class CreateLeaveAllocationDto 
{
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
}
