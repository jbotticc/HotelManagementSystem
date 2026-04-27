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
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when roomNumber is less than or equal to zero.
    /// </exception>
    /// <remarks>
    /// Preconditions:
    /// - roomNumber must be greater than zero
    /// 
    /// Postconditions:
    /// - Guest is added to the specified room
    /// </remarks>
    public void Add(int roomNumber, Guest guest);

    /// <summary>
    /// Retrieves all guests assigned to a specific room.
    /// </summary>
    /// <param name="roomNumber">The room number to search for.</param>
    /// <returns>A list of guests assigned to the room.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when roomNumber is less than or equal to zero.
    /// </exception>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when no guests are found for the room.
    /// </exception>
    /// <remarks>
    /// Preconditions:
    /// - roomNumber must be greater than zero
    /// 
    /// Postconditions:
    /// - Returns a copy of the guest list for the room
    /// </remarks>
    public List<Guest> GetByRoom(int roomNumber);

    /// <summary>
    /// Updates a guest's information in a specific room.
    /// </summary>
    /// <param name="roomNumber">The room number where the guest is staying.</param>
    /// <param name="guest">The guest with updated information.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when roomNumber is less than or equal to zero.
    /// </exception>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when the room or guest is not found.
    /// </exception>
    /// <remarks>
    /// Preconditions:
    /// - roomNumber must be greater than zero
    /// - guest must not be null
    /// 
    /// Postconditions:
    /// - Guest information is updated in the specified room
    /// </remarks>
    public void Update(int roomNumber, Guest guest);
    /// <summary>
    /// Removes a guest from a specific room.
    /// </summary>
    /// <param name="roomNumber">The room number where the guest is staying.</param>
    /// <param name="guest">The guest to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when roomNumber is less than or equal to zero.
    /// </exception>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when the room or guest is not found.
    /// </exception>
    /// <remarks>
    /// Preconditions:
    /// - roomNumber must be greater than zero
    /// - guest must not be null
    /// 
    /// Postconditions:
    /// - Guest is removed from the specified room
    /// </remarks>
    public void Delete(int roomNumber, Guest guest);

}