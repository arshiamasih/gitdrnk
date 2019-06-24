using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GitDrnk.Services.Data.Interface
{
    interface IRepository<T>
    {
        Task<bool> Upsert(T entry); 
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetSubSet(Expression<Func<T, bool>> filter);
        Task<T> GetById(string id);

        void Initialize();

        void Seed();
    }
}
