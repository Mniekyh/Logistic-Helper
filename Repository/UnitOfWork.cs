using LogisticHelper.DataAccess;
using LogisticHelper.Repository.IRepository;

namespace LogisticHelper.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Uzytkownik = new UzytkownikRepository(_db);
        }

        public IUzytkownikRepository Uzytkownik
        { get; private set;   }

        public void Save()
        {
           _db.SaveChanges();
        }
    }
}
