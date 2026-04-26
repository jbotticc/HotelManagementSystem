using HotelManagementSystem.Contracts;

namespace HotelManagementSystem.Services.Strategy;

public class RegularPricing : IPricingStrategy
{
    public float CalculatePrice(Room room)
    {
        if (room == null) throw new ArgumentNullException(nameof(room));
        return room.Price;
    }
}
