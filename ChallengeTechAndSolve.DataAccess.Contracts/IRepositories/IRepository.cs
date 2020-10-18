namespace ChallengeTechAndSolve.DataAccess.Contracts.IRepositories
{
    using System.Threading.Tasks;
    public interface IRepository<T> where T : class
    {
        Task<int> AddAsync(T model);
    }
}
