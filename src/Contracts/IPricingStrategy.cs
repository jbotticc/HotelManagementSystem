using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Contracts;

/// <summary>
/// Defines the contract for room pricing calculation strategies.
/// </summary>
public interface IPricingStrategy
{
    /// <summary>
    /// Calculates the price for a specific room based on the strategy's logic.
    /// </summary>
    /// <param name="room">The room for which the price is being calculated.</param>
    /// <param name="lengthOfStay">The length of stay.</param>
    /// <returns>The calculated price as a float.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="room"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="lengthOfStay"/> is not positive.</exception>
    /// <remarks>
    /// Preconditions: The <paramref name="room"/> object must not be null and should contain valid base price data.
    /// Postconditions: Returns a non-negative float representing the total calculated price for the room.
    /// </remarks>
    public float CalculatePrice(Room room, int lengthOfStay);

}
