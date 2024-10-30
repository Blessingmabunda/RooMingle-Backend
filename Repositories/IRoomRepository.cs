using System.Threading.Tasks;

namespace RoomApi.Models
{
   public interface IRoomRepository
{
    Task<Room> RegisterAsync(Room Room);
    Task<Room> GetByLocationAsync(string location);
    Task<Room> UpdateRoomAsync(Room Room);
    Task DeleteRoomAsync(string location);
    Task<IEnumerable<Room>> GetAllRoomsAsync();
}

}
