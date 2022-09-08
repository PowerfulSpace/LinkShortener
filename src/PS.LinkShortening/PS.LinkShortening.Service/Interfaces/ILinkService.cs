using PS.LinkShortening.Domain.Entities;
using PS.LinkShortening.Domain.Responses;

namespace PS.LinkShortening.Service.Interfaces
{
    public interface ILinkService
    {
        public Task<IBaseResponse<Link>> GetUnitAsync(int id);
        public Task<IBaseResponse<IEnumerable<Link>>> GetAllUnitsAsync();
        public Task<IBaseResponse<Link>> CreateUnitAsync(Link model);
        public Task<IBaseResponse<Link>> UpdateUnitAsync(Link model);
        public Task<IBaseResponse<Link>> DeleteUnitAsync(Link model);
    }
}
