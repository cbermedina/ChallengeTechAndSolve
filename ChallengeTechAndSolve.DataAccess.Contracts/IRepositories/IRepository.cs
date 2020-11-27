namespace ChallengeTechAndSolve.DataAccess.Contracts.IRepositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T model);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync( string id);
    }
}
