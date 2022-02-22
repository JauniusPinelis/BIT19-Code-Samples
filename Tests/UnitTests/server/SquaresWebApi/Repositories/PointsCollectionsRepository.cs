using Microsoft.EntityFrameworkCore;
using School_WebAPI_BE.Repositories;
using SquaresWebApi.Data;
using SquaresWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SquaresWebApi.Repositories
{
    public class PointsCollectionsRepository : RepositoryBase<PointsCollection>
    {
        public PointsCollectionsRepository(DataContext context) : base(context) { }

        public async Task<PointsCollection> GetByIdIncludedAsync(int id)
        {
            return await _context.PointsCollections.Include(p => p.Points).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<PointsCollection> GetByNameAsync(string name)
        {
            return await _context.PointsCollections.Include(c => c.Points).FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}