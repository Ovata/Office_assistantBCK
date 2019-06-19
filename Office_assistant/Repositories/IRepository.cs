using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Office_assistant.Repositories
{
    public interface _dataRepository<TEntity>
    {
      
            IEnumerable<TEntity> GetAll();
            TEntity Get(int id);
            void Add(TEntity entity);
            void Update(TEntity dbEntity, TEntity entity);
            void Delete(TEntity entity);

    }
}
