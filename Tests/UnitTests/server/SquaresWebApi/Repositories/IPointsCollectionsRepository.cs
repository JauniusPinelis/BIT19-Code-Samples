using SquaresWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SquaresWebApi.Repositories
{
    public interface IPointsCollectionsRepository
    {
        Task<PointsCollection> GetByIdIncludedAsync(int id);
        Task<PointsCollection> GetByNameAsync(string name);
        Task<List<PointsCollection>> GetAllAsync();
        Task<int> CreateAsync(PointsCollection entity);
        Task<PointsCollection> GetByIdAsync(int entityId);
        void PrepareCreateRange(List<PointsCollection> entities);
        void PrepareRemoveRange(List<PointsCollection> entities);
        Task RemoveAsync(PointsCollection entity);
        Task RemoveRangeAsync(List<PointsCollection> entities);
        Task UpdateAsync(PointsCollection entity);
    }
}