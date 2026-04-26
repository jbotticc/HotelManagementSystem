using HotelManagementSystem.Contracts;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Services;

public class PricingService : IPricingService
{
    private IPricingStrategy _pricingStrategy;

    public PricingService(IPricingStrategy pricingStrategy)
    {
        _pricingStrategy = pricingStrategy ?? throw new ArgumentNullException(nameof(pricingStrategy));
    }

    public void SetPricingStrategy(IPricingStrategy pricingStrategy)
    {
        _pricingStrategy = pricingStrategy ?? throw new ArgumentNullException(nameof(pricingStrategy));
    }

    public float CalculatePrice(Room room)
    {
        if (room == null) throw new ArgumentNullException(nameof(room));
        if (_pricingStrategy == null) throw new InvalidOperationException("Pricing strategy has not been initialized.");
        
        return _pricingStrategy.CalculatePrice(room);
    }
}

