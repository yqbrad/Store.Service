using System.Threading.Tasks;

namespace Store.Contracts._Base
{
    public interface IUnitOfWork
    {
        void InitiateDatabase();
        Task InitiateDatabaseAsync();

        void BeginTransaction();
        Task BeginTransactionAsync();

        int Commit();
        Task<int> CommitAsync();

        void Rollback();
        Task RollbackAsync();

        //IAppRepository App { get; }
    }
}