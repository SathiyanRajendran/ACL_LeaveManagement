using ACL.LeaveManagement.Application.DTOs.Common;

namespace ACL.LeaveManagement.Application.DTOs.LeaveType
{
    public class LeaveTypeDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
