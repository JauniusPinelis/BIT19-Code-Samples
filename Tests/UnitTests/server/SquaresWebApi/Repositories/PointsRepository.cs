using Microsoft.EntityFrameworkCore;
using School_WebAPI_BE.Repositories;
using SquaresWebApi.Data;
using SquaresWebApi.Models;
using System.Threading.Tasks;

namespace SquaresWebApi.Repositories
{
    public class PointsRepository : RepositoryBase<Point>, IPointsRepository
    {
        public PointsRepository(DataContext context) : base(context) { }

        public async Task<int> GetPointsCountByCollectionIdAsync(int collectionId)
        {
            return await _context.Points.CountAsync(p => p.PointsCollectionId == collectionId);
        }
    }
}
