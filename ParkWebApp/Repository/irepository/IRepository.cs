using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWebApp.Repository.irepository
{
    public interface IRepository<T> where T:class
    {
        Task<T> GetAsync(string url, int id);
        Task<IEnumerable<T>> GetsAsync(string url);
        Task<bool> CreateAsync(string url, T objToCreate);
        Task<bool> UpdateAsync(string url, T objToUpdate);
        Task<bool> DeleteAsync(string url, int id);

    }
}
