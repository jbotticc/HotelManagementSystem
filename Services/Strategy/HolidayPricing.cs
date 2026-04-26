using HotelManagementSystem.Contracts;

namespace HotelManagementSystem.Services.Strategy;

public class HolidayPricing : IPricingStrategy
{
    public float CalculatePrice(Room room)
    {
        if (room == null) throw new ArgumentNullException(nameof(room));
        return room.Price * 2f;
    }
}
