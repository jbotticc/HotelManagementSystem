using HotelManagementSystem.Contracts;
using HotelManagementSystem.Domain.Factory;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Services;

public class ManagerService : IManagerService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUserRepository _userRepository;

    public ManagerService(IRoomRepository roomRepository, IUserRepository userRepository)
    {
        _roomRepository = roomRepository;
        _userRepository = userRepository;
    }
    
    public int ViewRevenue()
    {
        IReadOnlyList<Room> rooms = _roomRepository.GetAll();

        var revenue = 0;
        foreach (var room in rooms)
        {
            if (!room.IsVacant)
            {
                revenue += room.Rent;
            }
        }
        
        return revenue;
    }

    public int ViewOccupancy()
    {
        IReadOnlyList<Room> rooms = _roomRepository.GetAll();
        
        var occupancy = 0;
        foreach (var room in rooms)
        {
            if (!room.IsVacant)
            {
                occupancy++;
            }
        }
        
        return occupancy;
    }

    public void CreateRoom(RoomFactory factory, int roomNumber, int bedCount)
    {
        if (factory == null)
        {
            throw new ArgumentNullException(nameof(factory));
        }
        
        var room = factory.CreateRoom(roomNumber, bedCount);
        _roomRepository.Add(room);
    }

    public void AddUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        
        _userRepository.Add(user);
    }
}