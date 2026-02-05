using System;
using ACL.LeaveManagement.Domain.Common;

namespace ACL.LeaveManagement.Domain
{
    public class LeaveRequest : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RequestComments { get; set; } = string.Empty;
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
        
        public string RequestingEmployeeId { get; set; } = string.Empty;
        
        public int LeaveTypeId { get; set; }
        public LeaveType? LeaveType { get; set; }
    }
}
