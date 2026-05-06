using HotelManagementSystem.Contracts;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Services;

public class FrontDeskService: IFrontDeskService
{
    private readonly IGuestRepository _guestRepository;
    private readonly IRoomRepository _roomRepository;
    public FrontDeskService(IGuestRepository guestRepository, IRoomRepository roomRepository)
    {
        _guestRepository = guestRepository ?? throw new ArgumentNullException(nameof(guestRepository));
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
    }

  
    public void CheckIn(int roomNumber, string name, string phoneNumber, int lengthOfStay)
    {
        if (roomNumber <= 0)
            throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be greater than zero.");

        if (lengthOfStay <= 0)
            throw new ArgumentOutOfRangeException(nameof(lengthOfStay), "Length of stay must be greater than zero.");

        Room? room = _roomRepository.GetByRoomNumber(roomNumber);

        if (!room.IsVacant)
            throw new InvalidOperationException("Room is already occupied.");

        DateTime checkoutDate = DateTime.Now.AddDays(lengthOfStay);

        Guest guest = new Guest(name, phoneNumber, checkoutDate);

        _guestRepository.Add(roomNumber, guest);

        room.MarkOccupied();
        _roomRepository.Update(room);
    }

    public void CheckOut(int roomNumber)
    {
        if (roomNumber <= 0)
            throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be greater than zero.");

        Room? room = _roomRepository.GetByRoomNumber(roomNumber);

        if (room.IsVacant)
        {
            throw new InvalidOperationException("No guest is currently checked in to this room.");
        }

        room.MarkVacant();
        _roomRepository.Update(room);
    }

    public List<Room> GetAvailableRooms()
    {
        return _roomRepository.GetAll().Where(r => r.IsVacant).ToList();
    }
}