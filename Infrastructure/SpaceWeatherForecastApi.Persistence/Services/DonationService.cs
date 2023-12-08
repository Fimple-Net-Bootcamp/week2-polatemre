using SpaceWeatherForecastApi.Application.Abstractions.Services;
using SpaceWeatherForecastApi.Application.DTOs.AstronimicalObject;
using SpaceWeatherForecastApi.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecastApi.Persistence.Services
{
    public class AstronimicalObjectService : IAstronimicalObjectService
    {
        readonly IAstronimicalObjectWriteRepository _donationWriteRepository;
        readonly IAstronimicalObjectReadRepository _donationReadRepository;

        public AstronimicalObjectService(IAstronimicalObjectWriteRepository donationWriteRepository, IAstronimicalObjectReadRepository donationReadRepository)
        {
            _donationWriteRepository = donationWriteRepository;
            _donationReadRepository = donationReadRepository;
        }

        public async Task CreateAstronimicalObjectAsync(CreateAstronimicalObject createAstronimicalObject)
        {
            var orderCode = (new Random().NextDouble() * 10000).ToString();
            orderCode = orderCode.Substring(orderCode.IndexOf(".") + 1, orderCode.Length - orderCode.IndexOf(".") - 1);

            try
            {
                await _donationWriteRepository.AddAsync(new()
                {
                    Phone = createAstronimicalObject.Phone,
                    Id = Guid.Parse(createAstronimicalObject.BasketId),
                    Description = createAstronimicalObject.Description,
                    AstronimicalObjectTypeId = new Guid("14bb7dae-7f79-4450-aec9-a3d2337ba29e"),
                    OrderCode = orderCode

                });
                await _donationWriteRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                var asd = "";
            }

        }

        public async Task<ListAstronimicalObject> GetAllAstronimicalObjectsAsync(int page, int size)
        {
            var query = _donationReadRepository.Table.Include(o => o.Basket)
                      .ThenInclude(b => b.User)
                      .Include(o => o.Basket)
                         .ThenInclude(b => b.BasketItems)
                         .ThenInclude(bi => bi.Activity);



            var data = query.Skip(page * size).Take(size);
            /*.Take((page * size)..size);*/


            //var data2 = from donation in data
            //            join completedAstronimicalObject in _completedAstronimicalObjectReadRepository.Table
            //               on donation.Id equals completedAstronimicalObject.AstronimicalObjectId into co
            //            from _co in co.DefaultIfEmpty()
            //            select new
            //            {
            //                Id = donation.Id,
            //                CreatedDate = donation.CreatedDate,
            //                OrderCode = donation.OrderCode,
            //                Basket = donation.Basket,
            //                Completed = _co != null ? true : false
            //            };

            return new()
            {
                TotalAstronimicalObjectCount = await query.CountAsync(),
                AstronimicalObjects = await data.Select(o => new
                {
                    Id = o.Id,
                    CreatedDate = o.CreatedDate,
                    OrderCode = o.OrderCode,
                    TotalPrice = o.Basket.BasketItems.Sum(bi => bi.Activity.ConstAmount * bi.Quantity),
                    UserName = o.Basket.User.UserName,
                    //o.Completed
                }).ToListAsync()
            };
        }

        public async Task<SingleAstronimicalObject> GetAstronimicalObjectByIdAsync(string id)
        {
            var data = _donationReadRepository.Table
                                 .Include(o => o.Basket)
                                     .ThenInclude(b => b.BasketItems)
                                         .ThenInclude(bi => bi.Activity);

            var data2 = await (from donation in data
                               join completedAstronimicalObject in _completedAstronimicalObjectReadRepository.Table
                                    on donation.Id equals completedAstronimicalObject.AstronimicalObjectId into co
                               from _co in co.DefaultIfEmpty()
                               select new
                               {
                                   Id = donation.Id,
                                   CreatedDate = donation.CreatedDate,
                                   OrderCode = donation.OrderCode,
                                   Basket = donation.Basket,
                                   Completed = _co != null ? true : false,
                                   Address = donation.Address,
                                   Description = donation.Description
                               }).FirstOrDefaultAsync(o => o.Id == Guid.Parse(id));

            return new()
            {
                Id = data2.Id.ToString(),
                BasketItems = data2.Basket.BasketItems.Select(bi => new
                {
                    bi.Product.Name,
                    bi.Product.Price,
                    bi.Quantity
                }),
                Address = data2.Address,
                CreatedDate = data2.CreatedDate,
                Description = data2.Description,
                OrderCode = data2.OrderCode,
                Completed = data2.Completed
            };
        }

        //    public async Task<(bool, CompletedAstronimicalObjectDTO)> CompleteAstronimicalObjectAsync(string id)
        //    {
        //        AstronimicalObject? donation = await _donationReadRepository.Table
        //            .Include(o => o.Basket)
        //            .ThenInclude(b => b.User)
        //            .FirstOrDefaultAsync(o => o.Id == Guid.Parse(id));

        //        if (donation != null)
        //        {
        //            await _completedAstronimicalObjectWriteRepository.AddAsync(new() { AstronimicalObjectId = Guid.Parse(id) });
        //            return (await _completedAstronimicalObjectWriteRepository.SaveAsync() > 0, new()
        //            {
        //                OrderCode = donation.OrderCode,
        //                AstronimicalObjectDate = donation.CreatedDate,
        //                Username = donation.Basket.User.UserName,
        //                EMail = donation.Basket.User.Email
        //            });
        //        }
        //        return (false, null);
        //    }
        //}
    }
}

