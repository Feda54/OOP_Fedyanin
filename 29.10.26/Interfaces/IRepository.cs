using System.Collections.Generic;

namespace _29._10._26
{
    public interface IRepository<T>
    {
        void Add(T item);
        List<T> GetAll();
        void Delete(int id);
    }
}
