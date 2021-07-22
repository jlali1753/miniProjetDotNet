using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Projet_DotNet_GLSI_N.Models.Repositores
{
    public interface IProduitRepository<TEntity>
    {

        IList<TEntity> List();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update(int id, TEntity entity);
        void Delete(int id);
    
    }
}
