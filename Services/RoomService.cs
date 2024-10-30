using System.Threading.Tasks;

namespace RoomApi.Models
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Room> RegisterAsync(Room room)
        {
            return await _roomRepository.RegisterAsync(room);
        }

        public async Task<Room> GetByLocationAsync(string location)
        {
            return await _roomRepository.GetByLocationAsync(location);
        }

        public async Task<Room> UpdateRoomAsync(Room room)
        {
            return await _roomRepository.UpdateRoomAsync(room);
        }

        public async Task DeleteRoomAsync(string location)
        {
            await _roomRepository.DeleteRoomAsync(location);
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _roomRepository.GetAllRoomsAsync();
        }
    }
}