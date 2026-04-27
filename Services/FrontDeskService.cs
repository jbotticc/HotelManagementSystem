using HotelManagementSystem.Contracts;
using HotelManagementSystem.Domain;

namespace HotelManagementSystem.Services;

public class FrontDeskService: IFrontDeskService
{
    private readonly IGuestRepository _guestRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IPricingService _pricingService;
    public FrontDeskService( IGuestRepository guestRepository, IRoomRepository roomRepository, IPricingService pricingService)
    {
        _guestRepository = guestRepository ?? throw new ArgumentNullException(nameof(guestRepository));
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        _pricingService = pricingService ?? throw new ArgumentNullException(nameof(pricingService));
    }

  
    public void CheckIn(int roomNumber, string name, string phoneNumber, int lengthOfStay)
    {
        if (roomNumber <= 0)
            throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be greater than zero.");

        if (lengthOfStay <= 0)
            throw new ArgumentOutOfRangeException(nameof(lengthOfStay), "Length of stay must be greater than zero.");

        Room? room = _roomRepository
            .GetAll()
            .FirstOrDefault(r => r.RoomNumber == roomNumber);

        if (room == null)
            throw new KeyNotFoundException("Room not found.");

        if (!room.Vacant)
            throw new InvalidOperationException("Room is already occupied.");

        DateTime checkoutDate = DateTime.Now.AddDays(lengthOfStay);

        Guest guest = new Guest(name, phoneNumber, checkoutDate);

        _guestRepository.Add(roomNumber, guest);

        room.Vacant = false;
        _roomRepository.Update(room);

        float price = _pricingService.CalculatePrice(room);
    }

    public void CheckOut(int roomNumber)
    {
        if (roomNumber <= 0)
            throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be greater than zero.");

        Room? room = _roomRepository
            .GetAll()
            .FirstOrDefault(r => r.RoomNumber == roomNumber);

        if (room == null)
            throw new KeyNotFoundException("Room not found.");

        List<Guest> guests = _guestRepository.GetByRoom(roomNumber);

        if (guests.Count == 0)
            throw new KeyNotFoundException("No guest found for this room.");

        foreach (Guest guest in guests)
        {
            _guestRepository.Delete(roomNumber, guest);
        }

        room.Vacant = true;
        _roomRepository.Update(room);
    }
}