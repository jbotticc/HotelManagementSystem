using HotelManagementSystem.Contracts;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly Dictionary<int, Room> _rooms = new();
    private static readonly RoomRepository _instance = new();
    
    private RoomRepository() {}
    
    public static RoomRepository GetInstance() => _instance;
    
    public void Add(Room room)
    {
        if (_rooms.ContainsKey(room.RoomNumber))
        {
            throw new InvalidOperationException($"Room {room.RoomNumber} already exists");
        }
        _rooms.Add(room.RoomNumber, room);
    }

    public IReadOnlyList<Room> GetAll()
    {
        return _rooms.Values.ToList();
    }

    public Room GetByRoomNumber(int roomNumber)
    {
        if (!_rooms.TryGetValue(roomNumber, out var room))
        {
            throw new InvalidOperationException($"Room {roomNumber} does not exist");
        }
        return room;
    }

    public void Update(Room room)
    {
        if (!_rooms.ContainsKey(room.RoomNumber))
        {
            throw new InvalidOperationException($"Room {room.RoomNumber} does not exist");
        }
        _rooms[room.RoomNumber] = room;
    }

    public void Delete(int roomNumber)
    {
        if (!_rooms.Remove(roomNumber))
        {
            throw new InvalidOperationException($"Room {roomNumber} does not exist");
        }
    }
}