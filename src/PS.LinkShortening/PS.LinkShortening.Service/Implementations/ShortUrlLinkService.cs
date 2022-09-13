using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using PS.LinkShortening.DAL.Interfaces;
using PS.LinkShortening.Domain.Entities;
using PS.LinkShortening.Domain.Enums;
using PS.LinkShortening.Domain.Responses;
using PS.LinkShortening.Service.Interfaces;
using PS.LinkShortening.Service.Models.Settings;

namespace PS.LinkShortening.Service.Implementations
{
    public class ShortUrlLinkService : IShortUrlLinkService
    {

        private readonly ILink _dbLinkRepository;
        private readonly IMemoryCache _cache;
        private readonly AppSettings _config;
        public ShortUrlLinkService(ILink dbContextRepository, IMemoryCache cache, IOptions<AppSettings> config)
        {
            _dbLinkRepository = dbContextRepository;
            _cache = cache;
            _config = config.Value;
        }





        public async Task<IBaseResponse<Link>> CreateAsync(Link model)
        {
            var baseResponse = new BaseResponse<Link>();

            var success = false;
            Exception? lastException = null;
            string key = model.Key;


            try
            {
                var link = await _dbLinkRepository.AddAsync(model);

                if (link == null)
                {
                    baseResponse.Description = "Link not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                }

                success = true;
            }
            catch (DbUpdateException dbUpdateException) when ((dbUpdateException.InnerException as SqlException)?.Number == 2601)
            {
                lastException = dbUpdateException;
                return new BaseResponse<Link>()
                {
                    Description = baseResponse.Description = $"[CreateAsync] : {dbUpdateException.Message}",
                    StatusCode = baseResponse.StatusCode = StatusCode.InternalServerError
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<Link>()
                {
                    Description = baseResponse.Description = $"[CreateAsync] : {e.Message}",
                    StatusCode = baseResponse.StatusCode = StatusCode.InternalServerError
                };
            }

            if (!success) { throw lastException!; }

            var cacheEntryOptions = new MemoryCacheEntryOptions();
            cacheEntryOptions.Size = 1;
            _cache.Set<Link>(key, model, cacheEntryOptions);


            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = model;
            return baseResponse;
        }

        public async Task<IBaseResponse<Link?>> GetAsync(string key)
        {
            var baseResponse = new BaseResponse<Link?>();


            try
            {
                var link = await _cache.GetOrCreateAsync<Link>(key, async entry =>
                {
                    var item = await _dbLinkRepository.GetAll().FirstOrDefaultAsync(u => u.Key == key);

                    if (item == null)
                        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_config.Cache.NegativeCacheTimeoutSeconds);
                    entry.Size = 1;

                    return item!;
                });


                if (link == null)
                {
                    baseResponse.Description = "Link not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                }

                //link!.CountTransitions = link!.CountTransitions + 1;
                //link = await _dbLinkRepository.EditAsync(link);

                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = link;
                return baseResponse;

            }
            catch (Exception e)
            {
                return new BaseResponse<Link?>()
                {
                    Description = baseResponse.Description = $"[GetAsync] : {e.Message}",
                    StatusCode = baseResponse.StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
