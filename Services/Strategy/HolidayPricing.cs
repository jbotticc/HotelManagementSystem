using HotelManagementSystem.Contracts;
using HotelManagementSystem.Domain.Models;
namespace HotelManagementSystem.Services.Strategy;

public class HolidayPricing : IPricingStrategy
{
    public float CalculatePrice(Room room, int lengthOfStay)
    {
        if (room == null) throw new ArgumentNullException(nameof(room));
        if (lengthOfStay <= 0) throw new ArgumentOutOfRangeException(nameof(lengthOfStay), "Length of stay must be positive.");
        return room.Rent * 2f * lengthOfStay / 7f;
    }
}

