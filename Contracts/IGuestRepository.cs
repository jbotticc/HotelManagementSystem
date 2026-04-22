using HotelManagementSystem.Domain;

namespace HotelManagementSystem.Contracts;

/// <summary>
/// Defines methods for managing guest records grouped by room number.
/// </summary>
public interface IGuestRepository
{
    /// <summary>
    /// Adds a guest to a specific room.
    /// </summary>
    /// <param name="roomNumber">The room number where the guest is staying.</param>
    /// <param name="guest">The guest to add.</param>
    public void Add(int roomNumber, Guest guest);

    /// <summary>
    /// Retrieves all guests assigned to a specific room.
    /// </summary>
    /// <param name="roomNumber">The room number to search for.</param>
    /// <returns>
    /// A list of guests in the specified room. Returns an empty list if no guests are found.
    /// </returns>
    public List<Guest> GetByRoom(int roomNumber);

    /// <summary>
    /// Updates a guest's information in a specific room.
    /// </summary>
    /// <param name="roomNumber">The room number where the guest is staying.</param>
    /// <param name="guest">The guest with updated information.</param>
    public void Update(int roomNumber, Guest guest);
    /// <summary>
    /// Removes a guest from a specific room.
    /// </summary>
    /// <param name="roomNumber">The room number where the guest is staying.</param>
    /// <param name="guest">The guest to remove.</param>
    public void Delete(int roomNumber, Guest guest);

}