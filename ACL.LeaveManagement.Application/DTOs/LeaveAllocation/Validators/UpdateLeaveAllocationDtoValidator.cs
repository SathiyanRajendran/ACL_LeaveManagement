using ACL.LeaveManagement.Application.Contracts.Persistence;
using ACL.LeaveManagement.Application.DTOs.LeaveAllocation;
using FluentValidation;

namespace ACL.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;

public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.NumberOfDays)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.");

        RuleFor(p => p.Period)
            .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}.");

        RuleFor(p => p.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(async (id, token) => {
                var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                return leaveTypeExists;
            })
            .WithMessage("{PropertyName} does not exist.");
    }
}
