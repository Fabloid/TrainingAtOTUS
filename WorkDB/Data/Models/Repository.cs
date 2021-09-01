using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models {
    public class Repository<T> where T : class {
        private readonly MyAppContext _db;

        public Repository(MyAppContext dbContext) {
            _db = dbContext;
        }

        public T Get(Expression<Func<T, bool>> predicate) {
            return _db.Set<T>().FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate) {
            return _db.Set<T>().Where(predicate);
        }

        public virtual T Get(int id) {
            return _db.Set<T>().Find(id);
        }

        public void Create(T item) {
            _db.Set<T>().Add(item);
        }

        public void CreateMany(IEnumerable<T> items) {
            _db.Set<T>().AddRange(items);
        }

        public void Update(T item) {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(T item) {
            _db.Set<T>().Remove(item);
        }
    }
}
