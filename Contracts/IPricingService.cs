using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Contracts;

/// <summary>
/// Defines the contract for a service that manages pricing strategies and calculates room prices.
/// </summary>
public interface IPricingService
{
    /// <summary>
    /// Sets the active pricing strategy to be used for price calculations.
    /// </summary>
    /// <param name="pricingStrategy">The pricing strategy implementation to use.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="pricingStrategy"/> is null.</exception>
    /// <remarks>
    /// Preconditions: The <paramref name="pricingStrategy"/> must not be null.
    /// Postconditions: The service will use the provided strategy for all subsequent price calculations until changed.
    /// </remarks>
    void SetPricingStrategy(IPricingStrategy pricingStrategy);

    /// <summary>
    /// Calculates the price for a specific room using the currently set pricing strategy.
    /// </summary>
    /// <param name="roomNumber">The room number to calculate the price for.</param>
    /// <param name="lengthOfStay">The length of stay.</param>
    /// <returns>The calculated price as a float.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the room cannot be found.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="lengthOfStay"/> is not positive.</exception>
    /// <remarks>
    /// Preconditions: A valid pricing strategy must have been set, room must exist in the system.
    /// Postconditions: Returns the price as determined by the active strategy's calculation logic.
    /// </remarks>
    float CalculatePrice(int roomNumber, int lengthOfStay);

}
