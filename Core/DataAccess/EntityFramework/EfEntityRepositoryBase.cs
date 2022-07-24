using Core.Entities;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
        public class EfEntityRepositoryBase<TEntity, Tcontext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where Tcontext : DbContext, new()
        {
       

        public void Add(TEntity entity)
        {
            using(Tcontext context = new Tcontext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using(Tcontext context = new Tcontext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using(Tcontext context =new Tcontext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList() 
                    : context.Set<TEntity>().ToList(); 
            }
        }

        public void Remove(TEntity entity)
        {
            using(Tcontext context = new Tcontext())
            {
                var removedEntity = context.Entry(entity);
                removedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using(Tcontext context = new Tcontext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                
            }
        }
    }
}
