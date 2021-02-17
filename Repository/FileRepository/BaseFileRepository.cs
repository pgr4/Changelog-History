using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Changelog_History.Repository.FileRepository
{
    public abstract class BaseFileRepository<T>
    {
        protected abstract string FileName { get; }

        public IEnumerable<T> GetAll()
        {
            if(!File.Exists(FileName))
            {
                File.Create(FileName).Close();
            }

            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(FileName));
        }

        public void Add(T item)
        {
            List<T> temp = GetAll()?.ToList() ?? new List<T>();
            temp.Add(item);
            File.WriteAllText(FileName, JsonConvert.SerializeObject(temp));
        }
    }
}