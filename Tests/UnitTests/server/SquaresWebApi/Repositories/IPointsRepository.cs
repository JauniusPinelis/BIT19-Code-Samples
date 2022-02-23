using SquaresWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SquaresWebApi.Repositories
{
    public interface IPointsRepository
    {
        Task<int> GetPointsCountByCollectionIdAsync(int collectionId);
        Task<int> CreateAsync(Point entity);
        Task<List<Point>> GetAllAsync();
        Task<Point> GetByIdAsync(int entityId);
        void PrepareCreateRange(List<Point> entities);
        void PrepareRemoveRange(List<Point> entities);
        Task RemoveAsync(Point entity);
        Task RemoveRangeAsync(List<Point> entities);
        Task UpdateAsync(Point entity);
    }
}
