using ACL.LeaveManagement.Application.Contracts.Persistence;
using ACL.LeaveManagement.Domain;
using ACL.LeaveManagement.Infrastructure.Persistence;

namespace ACL.LeaveManagement.Infrastructure.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
