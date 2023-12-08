using SpaceWeatherForecastApi.Application.Abstractions.Services;
using MediatR;

namespace SpaceWeatherForecastApi.Application.Features.Commands.Activities;

public class CreateAstronomicalObjectCommand : IRequest<CreateAstronomicalObjectCommandResponse>
{
    public string Description { get; set; }
    public string Name { get; set; }
    public int Distance { get; set; }
    public string Type { get; set; }

    public class CreateAstronomicalObjectCommandHandler : IRequestHandler<CreateAstronomicalObjectCommand, CreateAstronomicalObjectCommandResponse>
    {
        readonly IAstronomicalObjectService _astronomicalObjectService;

        public CreateAstronomicalObjectCommandHandler(IAstronomicalObjectService astronomicalObjectService)
        {
            _astronomicalObjectService = astronomicalObjectService;
        }

        public async Task<CreateAstronomicalObjectCommandResponse> Handle(CreateAstronomicalObjectCommand request, CancellationToken cancellationToken)
        {
            await _astronomicalObjectService.CreateAstronomicalObjectAsync(new()
            {
                Distance = request.Distance,
                Type = request.Type,
                Description = request.Description,
                Name = request.Name
            });

            return new();
        }
    }

}

public class CreateAstronomicalObjectCommandResponse
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public int Distance { get; set; }
    public string Type { get; set; }
}
