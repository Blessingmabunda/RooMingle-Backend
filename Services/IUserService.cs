using System.Threading.Tasks;

namespace UserApi.Models
{
    public interface IUserService
    {
        Task<User> RegisterAsync(User user);
        Task<User> LoginAsync(string username, string password);
    }
}
