using AutoMapper;
using Todo.Application.Interfaces.Repositories;
using Todo.Application.Models.Common;
using Todo.Domain;
using Todo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Todo.Infrastructure.Repositories
{
    /// <summary>
    /// Implementa operaciones basicas de una entidad.
    /// </summary>
    /// <typeparam name="TEntity">Entidad que se encuentra asociada a la BD.</typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
                              where TEntity : BaseEntity, IGenerateEntity<TEntity>
    {

        private readonly BaseDbContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(BaseDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
            this._dbSet = context.Set<TEntity>();
           
        }
        public IQueryable<TEntity> AsNoTracking()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }
        public void Create(TEntity entity)
        {   
            entity.createAt = DateTime.Now;
            _dbSet.Add(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                this.Create(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {

            entity.createAt = DateTime.Now;
            await _dbSet.AddAsync(entity);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                await this.CreateAsync(entity);
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }


        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                this.Delete(entity);
        }

        public void Delete(params object[] id)
        {
            TEntity entity = this.Find(id);
            if (entity != null)
                this.Delete(entity);
        }

        public async Task DeleteAsync(params object[] id)
        {
            TEntity entity = await this.FindAsync(id);
            if (entity != null)
                this.Delete(entity);
        }

        public EntityEntry<TEntity> Update(TEntity entity)
        {
            TEntity destination = entity.RecoverKey();
            _dbSet.Attach(destination);
            _context.Entry(destination).State = EntityState.Modified;
            _mapper.Map(entity, destination);
            destination.updateAt = DateTime.Now;
            var entry = _context.Entry(destination);
            return entry;
        }

    }
}
