using SpaceWeatherForecastApi.Application.Abstractions.Services;
using SpaceWeatherForecastApi.Application.DTOs.AstronomicalObject;
using SpaceWeatherForecastApi.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceWeatherForecastApi.Domain.Entities;

namespace SpaceWeatherForecastApi.Persistence.Services
{
    public class AstronomicalObjectService : IAstronomicalObjectService
    {
        readonly IAstronomicalObjectWriteRepository _astronomicalObjectWriteRepository;
        readonly IAstronomicalObjectReadRepository _astronomicalObjectReadRepository;

        public AstronomicalObjectService(IAstronomicalObjectWriteRepository astronomicalObjectWriteRepository, IAstronomicalObjectReadRepository astronomicalObjectReadRepository)
        {
            _astronomicalObjectWriteRepository = astronomicalObjectWriteRepository;
            _astronomicalObjectReadRepository = astronomicalObjectReadRepository;
        }

        public async Task CreateAstronomicalObjectAsync(CreateAstronomicalObject createAstronomicalObject)
        {
            try
            {
                await _astronomicalObjectWriteRepository.AddAsync(new()
                {
                    Distance = createAstronomicalObject.Distance,
                    Description = createAstronomicalObject.Description,
                    Name = createAstronomicalObject.Name,
                    Type = createAstronomicalObject.Type
                });
                await _astronomicalObjectWriteRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                var asd = "";
            }

        }

        public async Task<ListAstronomicalObject> GetAllAstronomicalObjectsAsync(int page, int size)
        {
            var query = _astronomicalObjectReadRepository.Table.Skip(page * size).Take(size); 

            return new()
            {
                TotalAstronomicalObjectCount = await query.CountAsync(),
                AstronomicalObjects = await query.Select(o => new
                {
                    Id = o.Id,
                    Name = o.Name,
                    CreatedDate = o.CreatedDate,
                    Type = o.Type,
                    Description = o.Description,
                    Distance = o.Distance,
                    UpdatedDate = o.UpdatedDate
                }).ToListAsync()
            };
        }

        public async Task<SingleAstronomicalObject> GetAstronomicalObjectByIdAsync(int id)
        {
            var data = await _astronomicalObjectReadRepository.GetByIdAsync(id);

            return new SingleAstronomicalObject()
            {
                Id = data.Id,
                CreatedDate = data.CreatedDate,
                Description = data.Description,
                Distance = data.Distance,
                Name = data.Name,
                Type = data.Type
            };
        }
    }
}