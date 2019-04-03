using HardwareHelpDesk.BLL.Repository.Abstracts;
using HardwareHelpDesk.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareHelpDesk.BLL.Repository
{
    public class RepoBase<T, TId> : IRepoBase<T, TId> where T : class
    {
        private readonly MyContext _DbContext;
        private readonly DbSet<T> _DbObject;

        public RepoBase(MyContext dbContext)
        {
            _DbContext = dbContext;
            _DbObject = _DbContext.Set<T>();
        }
        public void Insert(T entity)
        {
            _DbObject.Add(entity);
            _DbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            _DbObject.Remove(entity);
            _DbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _DbObject.Attach(entity);
            _DbContext.Entry(entity).State = EntityState.Modified;
        }

        public List<T> GetAll()
        {
            return _DbObject.ToList();
        }

        public List<T> GetAll(Func<T, bool> predicate)
        {
           return _DbObject.Where(predicate).ToList();
        }

        public List<T> GetAll(params string[] includes)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(Func<T, bool> predicate, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public T GetById(TId id)
        {
            return _DbObject.Find(id);
        }

        

        public IQueryable<T> Queryable()
        {
            return _DbObject.AsQueryable();
        }

        public IQueryable<T> Queryable(Func<T, bool> predicate)
        {
            return _DbObject.Where(predicate).AsQueryable();
        }

        
    }
}
