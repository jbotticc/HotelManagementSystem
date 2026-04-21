using HotelManagementSystem.Domain;

namespace HotelManagementSystem.Repositories;

public class GuestRepository: Contracts.IGuestRepository
{
    private Dictionary<int, Guest> _guests = new Dictionary<int, Guest>();
    private static GuestRepository _instance;

    private GuestRepository(){}

    public static GuestRepository GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GuestRepository();
        }
        return _instance;
    }
    
    public void Add(Guest guest)
    {
        _guests.Add(guest.RoomNumber, guest);
    }

    public Guest GetByRoom(int roomNumber)
    {
 if (_guests.TryGetValue(roomNumber, out Guest guest))
    {
        return guest;
    }

    throw new KeyNotFoundException("Guest not found for this room.");    }


    public void Update(Guest guest)
    {
        if (_guests.ContainsKey(guest.RoomNumber))
        {
            _guests[guest.RoomNumber] = guest;
        }
    }

    public void Delete(Guest guest)
    {
        _guests.Remove(guest.RoomNumber);
    }

}