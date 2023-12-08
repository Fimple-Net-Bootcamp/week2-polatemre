using SpaceWeatherForecastApi.Application.Features.Commands.Activities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SpaceWeatherForecastApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AstronomicalObjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AstronomicalObjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] GetAllAstronomicalObjectsQuery getAllAstronomicalObjectsQueryRequest)
    {
        GetAllAstronomicalObjectsQueryResponse response = await _mediator.Send(getAllAstronomicalObjectsQueryRequest);
        return Ok(response);
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult> GetById([FromRoute] GetAstronomicalObjectByIdQuery getAstronomicalObjectByIdQueryRequest)
    {
        GetAstronomicalObjectByIdQueryResponse response = await _mediator.Send(getAstronomicalObjectByIdQueryRequest);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAstronomicalObjectCommand createAstronomicalObjectCommand)
    {
        CreateAstronomicalObjectCommandResponse response = await _mediator.Send(createAstronomicalObjectCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAstronomicalObjectCommand createAstronomicalObjectCommand)
    {
        CreateAstronomicalObjectCommandResponse response = await _mediator.Send(createAstronomicalObjectCommand);
        return Ok(response);
    }

    [HttpPatch]
    public async Task<IActionResult> Patch(PatchAstronomicalObjectCommand createAstronomicalObjectCommand)
    {
        CreateAstronomicalObjectCommandResponse response = await _mediator.Send(createAstronomicalObjectCommand);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] GetAllAstronomicalObjectsQuery getAllAstronomicalObjectsQueryRequest)
    {
        GetAllAstronomicalObjectsQueryResponse response = await _mediator.Send(getAllAstronomicalObjectsQueryRequest);
        return Ok(response);
    }

}
