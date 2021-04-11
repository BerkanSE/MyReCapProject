using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        object Get(string key);
        //Generic olmayan alternetifi 

        void Add(string key, object value, int duration);
        bool IsAdd(string key);
        //Cache'de var mı yoksa veritabanından mı getirilicek?

        void Remove(string key);
        //Cache'den uçurma

        void RemoveByPattern(string pattern);
        //Design'a göre cache'den uçurma

    }
}
