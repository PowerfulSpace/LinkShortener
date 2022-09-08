using PS.LinkShortening.Domain.Entities;
using PS.LinkShortening.Domain.Responses;

namespace PS.LinkShortening.Service.Interfaces
{
    public interface ILinkService
    {
        public Task<IBaseResponse<Link>> GetLinkAsync(int id);
        public Task<IBaseResponse<IEnumerable<Link>>> GetAllLinksAsync();
        public Task<IBaseResponse<Link>> CreateLinkAsync(Link model);
        public Task<IBaseResponse<Link>> UpdateLinkAsync(Link model);
        public Task<IBaseResponse<Link>> DeleteLinkAsync(Link model);
    }
}
