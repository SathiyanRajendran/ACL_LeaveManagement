using ACL.LeaveManagement.Application.DTOs.LeaveAllocation;
using ACL.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using ACL.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ACL.LeaveManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveAllocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveAllocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<LeaveAllocationDto>>> Get(bool isLoggedInUser = false)
    {
        var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());
        return Ok(leaveAllocations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
    {
        var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
        return Ok(leaveAllocation);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto leaveAllocation)
    {
        var command = new CreateLeaveAllocationCommand { CreateLeaveAllocationDto = leaveAllocation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto leaveAllocation)
    {
        var command = new UpdateLeaveAllocationCommand { UpdateLeaveAllocationDto = leaveAllocation };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLeaveAllocationCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
