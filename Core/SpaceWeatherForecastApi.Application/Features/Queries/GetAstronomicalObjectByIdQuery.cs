using MediatR;
using SpaceWeatherForecastApi.Application.Abstractions.Services;

namespace SpaceWeatherForecastApi.Application.Features.Commands.Activities
{
    public class GetAstronomicalObjectByIdQuery : IRequest<GetAstronomicalObjectByIdQueryResponse>
    {
        public int Id { get; set; }

        public class GetAstronomicalObjectByIdQueryHandler : IRequestHandler<GetAstronomicalObjectByIdQuery, GetAstronomicalObjectByIdQueryResponse>
        {
            readonly IAstronomicalObjectService _donationService;

            public GetAstronomicalObjectByIdQueryHandler(IAstronomicalObjectService donationService)
            {
                _donationService = donationService;
            }

            public async Task<GetAstronomicalObjectByIdQueryResponse> Handle(GetAstronomicalObjectByIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _donationService.GetAstronomicalObjectByIdAsync(request.Id);

                return new()
                {
                    Id = data.Id,
                    CreatedDate = data.CreatedDate,
                    Description = data.Description,
                    Name = data.Name,
                    Distance = data.Distance,
                    Type = data.Type
                };

            }
        }
    }

    public class GetAstronomicalObjectByIdQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Distance { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
