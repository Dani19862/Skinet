using System.Collections;
using Core.Entities;
using Core.Interfaces;
using Infrastruture.Data;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly StoreContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            // get the name of the entity 
            var type = typeof(TEntity).Name;

            // check if the hashtable contains an entry for the entity with specific name
            if(!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                // if there is not repo already for this type => create instance of the entity
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)),_context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>) _repositories[type];
        }
    }
}