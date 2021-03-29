using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Burada T'yi sınırlandırmak istiyoruz : Generic constraint
    //class : Referans tip -- yani değer tipler veremeyiz.(like int)
    //Classların hepsinin ortak özelliği IEntity olması
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new() : new'lenebilir olmalı
    //IEntity new'lenemez. (Soyut bir nesne --> interface)
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //Veritabanı nesneleriyle çalışan bir repository oluşturduk
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        //filter = null : filtrede vermeyebilirsin demektir.
        //Expression func'ın görevi sadece bir veri çekmek içindir.
        T Get(Expression<Func<T, bool>> filter);
        //Burada filtre vermek zorunludur
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //List<Car> GetById(int Id);
        //Bunu kaldırmamızın nedeni yukarıdaki expressiondandır.
        //İhtiyaç kalmıyor çünkü filtreli method yazıyoruz.
    }
}
