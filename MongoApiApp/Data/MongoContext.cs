using MongoApiApp.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoApiApp.Data
{
    public class MongoContext
    {
        private readonly IMongoCollection<User> _users;

        public MongoContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("MongoApiDB");
            _users = database.GetCollection<User>("users");
        }

        public async Task<List<User>> GetAllUsersAsync() => await _users.Find(user => true).ToListAsync();

        public async Task<User> CreateUserAsync(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }
    }
}
