using HotelManagementSystem.Contracts;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Services;

public class PricingService : IPricingService
{
    private IPricingStrategy _pricingStrategy;
    private IRoomRepository _roomRepository;

    public PricingService(IPricingStrategy pricingStrategy, IRoomRepository roomRepository)
    {
        _pricingStrategy = pricingStrategy ?? throw new ArgumentNullException(nameof(pricingStrategy));
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
    }

    public void SetPricingStrategy(IPricingStrategy pricingStrategy)
    {
        _pricingStrategy = pricingStrategy ?? throw new ArgumentNullException(nameof(pricingStrategy));
    }

    public float CalculatePrice(int roomNumber, int lengthOfStay)
    {
        Room room = _roomRepository.GetByRoomNumber(roomNumber);
        
        return _pricingStrategy.CalculatePrice(room, lengthOfStay);
    }
}

