using MongoDB.Driver;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;


namespace UserApi.Models
{
   public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _users;

    public UserRepository(IOptions<MongoDBSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _users = database.GetCollection<User>("Users");
    }

    public async Task<User> RegisterAsync(User user)
    {
        await _users.InsertOneAsync(user);
        return user;
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        return await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        var result = await _users.ReplaceOneAsync(u => u.Username == user.Username, user);
        return result.IsAcknowledged ? user : null;
    }

    public async Task DeleteUserAsync(string username)
    {
        await _users.DeleteOneAsync(u => u.Username == username);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _users.Find(_ => true).ToListAsync();
    }
}

}
