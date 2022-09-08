using Microsoft.EntityFrameworkCore;
using PS.LinkShortening.DAL.Interfaces;
using PS.LinkShortening.Domain.Entities;
using PS.LinkShortening.Domain.Enums;
using PS.LinkShortening.Domain.Responses;
using PS.LinkShortening.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.LinkShortening.Service.Implementations
{
    public class LinkService : ILinkService
    {
        private readonly ILink _dbLinkRepository;
        public LinkService(ILink dbContextRepository) => _dbLinkRepository = dbContextRepository;


        public async Task<IBaseResponse<Link>> GetUnitAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<IEnumerable<Link>>> GetAllUnitsAsync()
        {
            var baseResponse = new BaseResponse<IEnumerable<Link>>();


            try
            {
                var links = await _dbLinkRepository.GetAll().ToListAsync();

                if(links == null)
                {
                    baseResponse.Description = "Link not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                }
                baseResponse.StatusCode = StatusCode.NotFound;
                baseResponse.Data = links;
                return baseResponse;

            }
            catch (Exception e)
            {
                return new BaseResponse<IEnumerable<Link>>()
                {
                    Description = baseResponse.Description = $"[GetAllUnitsAsync] : {e.Message}",
                    StatusCode = baseResponse.StatusCode = StatusCode.NotFound
                };
            }

        }

        public async Task<IBaseResponse<Link>> CreateUnitAsync(Link model)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<Link>> UpdateUnitAsync(Link model)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<Link>> DeleteUnitAsync(Link model)
        {
            throw new NotImplementedException();
        }
    }
}
