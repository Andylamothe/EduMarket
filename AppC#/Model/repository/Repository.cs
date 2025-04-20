using Microsoft.EntityFrameworkCore;
using Model.DataBase;

namespace Model.repository
{
    /*
     * Cette interface est la pour definir les methodes de base que tout les repository vont devoir implementer.
     * Comme cela si on veux creer un repository personnelle on va pouvoir, il faudra juste implementer cette interface. et modifier ces requetes
     */
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
    
    /*
     * Cette est classes est exactement comme les repository de spring boot, mais la seul vrai difference, cet qu'il a moins de choix de requete.
     * Cela va etre a nous de faire les requetes Linq qui nous conviennent.
     * Mais ce repository est la pour nous simplifier la vie et ne pas avoir a ecrire tout le temps le meme code.
     */
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataBaseContext _context;

        public Repository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().OfType<TEntity>().ToListAsync();
        }


        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
