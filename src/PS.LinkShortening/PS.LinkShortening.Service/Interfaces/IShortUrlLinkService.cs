using PS.LinkShortening.Domain.Entities;
using PS.LinkShortening.Domain.Responses;

namespace PS.LinkShortening.Service.Interfaces
{
    public interface IShortUrlLinkService
    {
        public Task<IBaseResponse<Link>> CreateAsync(Link model);
        public Task<IBaseResponse<Link?>> GetAsync(string key);
    }
}
