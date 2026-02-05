using ACL.LeaveManagement.Application.Contracts.Persistence;
using ACL.LeaveManagement.Application.DTOs.LeaveType.Validators;
using ACL.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using ACL.LeaveManagement.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ACL.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
                throw new Exceptions.ValidationException(validationResult);

            var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);
            
            await _leaveTypeRepository.CreateAsync(leaveType);
            
            return leaveType.Id;
        }
    }
}
