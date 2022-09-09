using Microsoft.EntityFrameworkCore;
using PS.LinkShortening.DAL.Interfaces;
using PS.LinkShortening.Domain.Entities;
using PS.LinkShortening.Domain.Enums;
using PS.LinkShortening.Domain.Responses;
using PS.LinkShortening.Service.Interfaces;

namespace PS.LinkShortening.Service.Implementations
{
    public class LinkService : ILinkService
    {
        private readonly ILink _dbLinkRepository;
        public LinkService(ILink dbContextRepository) => _dbLinkRepository = dbContextRepository;


        public async Task<IBaseResponse<Link>> GetLinkAsync(int id)
        {
            var baseResponse = new BaseResponse<Link>();


            try
            {
                var link = await _dbLinkRepository.GetAsync(id);

                if (link == null)
                {
                    baseResponse.Description = "Link not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                }
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = link;
                return baseResponse;

            }
            catch (Exception e)
            {
                return new BaseResponse<Link>()
                {
                    Description = baseResponse.Description = $"[GetAllLinksAsync] : {e.Message}",
                    StatusCode = baseResponse.StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Link>>> GetAllLinksAsync()
        {
            var baseResponse = new BaseResponse<IEnumerable<Link>>();


            try
            {
                var links = await _dbLinkRepository.GetAll().ToListAsync();

                if(links == null)
                {
                    baseResponse.Description = "Links not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                }
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = links;
                return baseResponse;

            }
            catch (Exception e)
            {
                return new BaseResponse<IEnumerable<Link>>()
                {
                    Description = baseResponse.Description = $"[GetAllLinksAsync] : {e.Message}",
                    StatusCode = baseResponse.StatusCode = StatusCode.InternalServerError
                };
            }

        }

        public async Task<IBaseResponse<Link>> CreateLinkAsync(Link model)
        {
            var baseResponse = new BaseResponse<Link>();


            try
            {
                var link = await _dbLinkRepository.AddAsync(model);

                if (link == null)
                {
                    baseResponse.Description = "Link not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                }
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = link;
                return baseResponse;

            }
            catch (Exception e)
            {
                return new BaseResponse<Link>()
                {
                    Description = baseResponse.Description = $"[CreateLinkAsync] : {e.Message}",
                    StatusCode = baseResponse.StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Link>> UpdateLinkAsync(Link model)
        {
            var baseResponse = new BaseResponse<Link>();


            try
            {
                var link = await _dbLinkRepository.EditAsync(model);

                if (link == null)
                {
                    baseResponse.Description = "Link not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                }
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = link;
                return baseResponse;

            }
            catch (Exception e)
            {
                return new BaseResponse<Link>()
                {
                    Description = baseResponse.Description = $"[UpdateLinkAsync] : {e.Message}",
                    StatusCode = baseResponse.StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Link>> DeleteLinkAsync(Link model)
        {
            var baseResponse = new BaseResponse<Link>();


            try
            {
                var link = await _dbLinkRepository.DeleteAsync(model);

                if (link == null)
                {
                    baseResponse.Description = "Link not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                }
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = link;
                return baseResponse;

            }
            catch (Exception e)
            {
                return new BaseResponse<Link>()
                {
                    Description = baseResponse.Description = $"[DeleteLinkAsync] : {e.Message}",
                    StatusCode = baseResponse.StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
