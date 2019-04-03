using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareHelpDesk.BLL.Repository.Abstracts
{
    public interface IRepoBase<T, TId> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
        List<T> GetAll(Func<T, bool> predicate);
        List<T> GetAll(params string[] includes);
        List<T> GetAll(Func<T, bool> predicate, params string[] includes);
        T GetById(TId id);
        IQueryable<T> Queryable();
        IQueryable<T> Queryable(Func<T, bool> predicate);
    }
}
