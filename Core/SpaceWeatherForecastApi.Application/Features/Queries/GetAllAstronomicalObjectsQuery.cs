using MediatR;
using SpaceWeatherForecastApi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecastApi.Application.Features.Commands.Activities
{
    public class GetAllAstronomicalObjectsQuery : IRequest<GetAllAstronomicalObjectsQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;

        public class GetAllAstronomicalObjectsQueryHandler : IRequestHandler<GetAllAstronomicalObjectsQuery, GetAllAstronomicalObjectsQueryResponse>
        {
            readonly IAstronomicalObjectService _donationService;

            public GetAllAstronomicalObjectsQueryHandler(IAstronomicalObjectService donationService)
            {
                _donationService = donationService;
            }

            public async Task<GetAllAstronomicalObjectsQueryResponse> Handle(GetAllAstronomicalObjectsQuery request, CancellationToken cancellationToken)
            {
                var data = await _donationService.GetAllAstronomicalObjectsAsync(request.Page, request.Size);

                return new()
                {
                    TotalAstronomicalObjectCount = data.TotalAstronomicalObjectCount,
                    AstronomicalObjects = data.AstronomicalObjects
                };
            }
        }

    }

    public class GetAllAstronomicalObjectsQueryResponse
    {
        public int TotalAstronomicalObjectCount { get; set; }
        public object AstronomicalObjects { get; set; }
    }
}
