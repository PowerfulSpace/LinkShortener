using Microsoft.EntityFrameworkCore;
using PS.LinkShortening.DAL.Data;
using PS.LinkShortening.DAL.Interfaces;
using PS.LinkShortening.Domain.Entities;

namespace PS.LinkShortening.DAL.Repositories
{
    public class LinkRepository : ILink
    {

        private readonly ApplicationDbContext _dbContext;
        public LinkRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public IQueryable<Link> GetAll() => _dbContext.Links;

        public async Task<Link> GetAsync(Guid id) => await _dbContext.Links.FirstOrDefaultAsync(x => x.Id == id);


        public async Task<Link> AddAsync(Link entity)
        {
            if(entity == null) { return null!; }

            try
            {
                _dbContext.Links.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }
            
            return entity;
        }

        public async Task<Link> EditAsync(Link entity)
        {
            if (entity == null) { return null!; }

            try
            {
                _dbContext.Links.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }

            return entity;
        }

        public async Task<Link> DeleteAsync(Link entity)
        {
            if (entity == null) { return null!; }

            try
            {
                _dbContext.Links.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }

            return entity;
        }



    }
}
