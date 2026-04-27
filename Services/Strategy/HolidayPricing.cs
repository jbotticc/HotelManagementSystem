using HotelManagementSystem.Contracts;
using HotelManagementSystem.Domain.Models;
namespace HotelManagementSystem.Services.Strategy;

public class HolidayPricing : IPricingStrategy
{
    public float CalculatePrice(Room room)
    {
        if (room == null) throw new ArgumentNullException(nameof(room));
        return room.Rent * 2f;
    }
}

