using System.Collections.Generic;

namespace Changelog_History.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(string name);
        void Add(T item);
    }
}