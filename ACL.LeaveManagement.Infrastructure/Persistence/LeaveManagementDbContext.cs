using ACL.LeaveManagement.Domain;
using ACL.LeaveManagement.Domain.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ACL.LeaveManagement.Infrastructure.Persistence
{
    public class LeaveManagementDbContext : IdentityDbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.DateModified = DateTime.Now;
                
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    // TODO: Set CreatedBy from Service
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
