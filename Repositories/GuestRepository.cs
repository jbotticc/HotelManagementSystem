using HotelManagementSystem.Domain;

namespace HotelManagementSystem.Repositories;

public class GuestRepository : Contracts.IGuestRepository
{
    private readonly Dictionary<int, List<Guest>> _guests = new();
    private static GuestRepository _instance;

    private GuestRepository() { }

    public static GuestRepository GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GuestRepository();
        }
        return _instance;
    }

    public void Add(int roomNumber, Guest guest)
    {
  
        if (roomNumber <= 0)
        {
            throw new ArgumentException("Room number must be greater than zero.");
        }
        if (!_guests.ContainsKey(roomNumber))
        {
            _guests[roomNumber] = new List<Guest>();
        }

        _guests[roomNumber].Add(guest);
    }

    public List<Guest> GetByRoom(int roomNumber)
    {
        if (roomNumber <= 0)
            throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be greater than zero.");

        if (!_guests.TryGetValue(roomNumber, out List<Guest>? guests))
            throw new KeyNotFoundException("No guests found for this room.");
            
        return new List<Guest>(guests);
    }

    public void Update(int roomNumber, Guest guest)
    {
        if (roomNumber <= 0)
            throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be greater than zero.");

        if (!_guests.ContainsKey(roomNumber))
            throw new KeyNotFoundException("Room not found.");

        int index = _guests[roomNumber].FindIndex(g => g.PhoneNumber == guest.PhoneNumber);

        if (index == -1)
            throw new KeyNotFoundException("Guest not found in this room.");

        _guests[roomNumber][index] = guest;
    }

    public void Delete(int roomNumber, Guest guest)
    {
        if (roomNumber <= 0)
            throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be greater than zero.");


        if (!_guests.ContainsKey(roomNumber))
            throw new KeyNotFoundException("Room not found.");

        int removedCount = _guests[roomNumber].RemoveAll(g => g.PhoneNumber == guest.PhoneNumber);

        if (removedCount == 0)
            throw new KeyNotFoundException("Guest not found in this room.");

        if (_guests[roomNumber].Count == 0)
        {
            _guests.Remove(roomNumber);
        }
    }
}