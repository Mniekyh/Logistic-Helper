using LogisticHelper.Models;

namespace LogisticHelper.Repository.IRepository
{
    public interface IUzytkownikRepository:IRepository<Uzytkownik>

    {
        void Update(Uzytkownik obj);

    }
}
