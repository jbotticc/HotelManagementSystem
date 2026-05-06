using HotelManagementSystem.Contracts;
using HotelManagementSystem.Domain.Factory;
using HotelManagementSystem.Domain.Models;
using HotelManagementSystem.Domain.Enums;

namespace HotelManagementSystem.Services;

public class ManagerService : IManagerService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPricingService _pricingService;

    public ManagerService(IRoomRepository roomRepository, IUserRepository userRepository, IPricingService pricingService)
    {
        _roomRepository = roomRepository;
        _userRepository = userRepository;
        _pricingService = pricingService;
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

    public User AddUser(Role role)
    {
        int newId = _userRepository.GetNextUserId();
        User newUser = new User(newId, role);
        _userRepository.Add(newUser);
        return newUser;
    }

    public void SetPricingStrategy(IPricingStrategy strategy)
    {
        if (strategy == null)
        {
            throw new ArgumentNullException(nameof(strategy));
        }
        
        _pricingService.SetPricingStrategy(strategy);
    }
}