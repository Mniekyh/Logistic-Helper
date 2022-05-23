using LogisticHelper.Repository.IRepository;
using LogisticHelper.Models;
using LogisticHelper.DataAccess;

namespace LogisticHelper.Repository
{
    public class UzytkownikRepository : Repository<Uzytkownik>, IUzytkownikRepository

    {
        private ApplicationDbContext _db;

        public UzytkownikRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
 

        public void Update(Uzytkownik obj)
        {
            _db.Uzytkownik.Update(obj);
        }
    }
}
