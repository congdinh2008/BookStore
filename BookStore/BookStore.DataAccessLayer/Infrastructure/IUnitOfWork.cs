using System.Threading.Tasks;

namespace BookStore.DataAccessLayer
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
