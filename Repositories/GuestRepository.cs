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
        if (!_guests.ContainsKey(roomNumber))
        {
            _guests[roomNumber] = new List<Guest>();
        }

        _guests[roomNumber].Add(guest);
    }

    public List<Guest> GetByRoom(int roomNumber)
    {
        if (_guests.TryGetValue(roomNumber, out List<Guest> guests))
        {
            return new List<Guest>(guests);
        }

        return new List<Guest>();
    }

    public void Update(int roomNumber, Guest guest)
    {
        if (_guests.ContainsKey(roomNumber))
        {
            int index = _guests[roomNumber].FindIndex(g => g.PhoneNumber == guest.PhoneNumber);
            if (index != -1)
            {
                _guests[roomNumber][index] = guest;
            }
        }
    }

    public void Delete(int roomNumber, Guest guest)
    {
        if (_guests.ContainsKey(roomNumber))
        {
            _guests[roomNumber].RemoveAll(g => g.PhoneNumber == guest.PhoneNumber);

            if (_guests[roomNumber].Count == 0)
            {
                _guests.Remove(roomNumber);
            }
        }
    }
}