using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            //Garbage collect
            //dispose : bellekten hızlıca silme
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                //Referansı yakalama
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                //Referansı yakalama
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        //Primary Key sayesinde bu metodu oluştururuz.
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        //Burada tek ürün bulacağımız için List kullanmayız.
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
                //1+ fazla değer dönerse SingleOrDefault hata verir.
                //FirstOrDefault'tan farkı 1+ fazla değer dönüyorsa ilkini verir.
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //Turnary yapısı, filter null ise ?'den sonraki ilk kısım çalışır
                //değilse :'den sonraki ikinci kısım çalışır.
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                //Referansı yakalama 
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
