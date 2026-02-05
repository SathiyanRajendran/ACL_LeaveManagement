using ACL.LeaveManagement.Application.Contracts.Persistence;
using ACL.LeaveManagement.Application.Exceptions;
using ACL.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using ACL.LeaveManagement.Domain;
using MediatR;

namespace ACL.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;

public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.Id);

        if (leaveAllocation == null)
            throw new NotFoundException(nameof(LeaveAllocation), request.Id);

        await _leaveAllocationRepository.DeleteAsync(leaveAllocation);
        return Unit.Value;
    }
}
