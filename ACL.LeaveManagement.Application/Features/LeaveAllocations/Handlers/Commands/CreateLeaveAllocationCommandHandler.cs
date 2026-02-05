using ACL.LeaveManagement.Application.Contracts.Persistence;
using ACL.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using ACL.LeaveManagement.Application.Exceptions;
using ACL.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using ACL.LeaveManagement.Domain;
using AutoMapper;
using MediatR;

namespace ACL.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.CreateLeaveAllocationDto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);

        var leaveAllocation = _mapper.Map<LeaveAllocation>(request.CreateLeaveAllocationDto);
        
        // Populate NumberOfDays from LeaveType default
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.CreateLeaveAllocationDto.LeaveTypeId);
        leaveAllocation.NumberOfDays = leaveType.DefaultDays;

        await _leaveAllocationRepository.CreateAsync(leaveAllocation);
        return leaveAllocation.Id;
    }
}
