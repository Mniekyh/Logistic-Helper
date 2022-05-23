using LogisticHelper.DataAccess;

namespace LogisticHelper.Repository.IRepository
{
    
    public interface IUnitOfWork
    {
        IUzytkownikRepository Uzytkownik{get;}

    void Save();

    }
}
