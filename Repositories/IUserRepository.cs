using System.Threading.Tasks;

namespace UserApi.Models
{
    public interface IUserRepository
    {
        Task<User> RegisterAsync(User user);
        Task<User> GetByUsernameAsync(string username);
    }
}
