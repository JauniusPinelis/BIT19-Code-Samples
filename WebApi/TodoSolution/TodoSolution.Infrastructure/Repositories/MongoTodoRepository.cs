using MongoDB.Driver;
using TodoSolution.Domain.Interfaces;
using TodoSolution.Domain.Models;

namespace TodoSolution.Infrastructure.Repositories
{
    public class MongoTodoRepository : ITodoRepository
    {
        private readonly IMongoCollection<Todo> _todoCollection;

        public MongoTodoRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase("TestDatabase");
            _todoCollection = mongoDatabase.GetCollection<Todo>("Todos");
        }

        public async Task<int> CreateAsync(Todo todo)
        {
            await _todoCollection.InsertOneAsync(todo);
            return 0;
        }

        public async Task<bool> DoesExist(string name)
        {
            return await _todoCollection.Find(x => x.FullName == name).AnyAsync();
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _todoCollection.Find(_ => true).ToListAsync();

        }

        public async Task<Todo> GetByIdAsync(string id)
        {
            return await _todoCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Todo todo)
        {
            await _todoCollection.DeleteOneAsync(t => t.Id == todo.Id);
        }
    }
}
