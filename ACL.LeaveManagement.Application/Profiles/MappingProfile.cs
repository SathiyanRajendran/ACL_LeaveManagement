using ACL.LeaveManagement.Application.DTOs.LeaveType;
using ACL.LeaveManagement.Application.DTOs.LeaveAllocation;
using ACL.LeaveManagement.Domain;
using AutoMapper;

namespace ACL.LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();
        }
    }
}
