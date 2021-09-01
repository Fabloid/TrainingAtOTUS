using Data.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models {
    public class UnitOfWork : IDisposable {
        private MyAppContext _db;

        public UnitOfWork(MyAppContext dbContext) {
            _db = dbContext;
        }

        private Repository<User> userRepository;
        public Repository<User> User {
            get {
                if (userRepository == null)
                    userRepository = new Repository<User>(_db);
                return userRepository;
            }
        }

        private Repository<Ad> adRepository;
        public Repository<Ad> Ad {
            get {
                if (adRepository == null)
                    adRepository = new Repository<Ad>(_db);
                return adRepository;
            }
        }

        private Repository<Category> categoryRepository;
        public Repository<Category> Category {
            get {
                if (categoryRepository == null)
                    categoryRepository = new Repository<Category>(_db);
                return categoryRepository;
            }
        }

        public void Save() {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
