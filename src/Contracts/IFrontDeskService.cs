using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Contracts;
/// <summary>
/// Defines operations for front desk services such as guest check-in and check-out.
/// </summary>
public interface IFrontDeskService
{
    /// <summary>
    /// Checks a guest into a room.
    /// </summary>
    /// <param name="roomNumber">The room number the guest will check into.</param>
    /// <param name="name">The name of the guest.</param>
    /// <param name="phoneNumber">The guest's phone number.</param>
    /// <param name="lengthOfStay">The number of days the guest will stay.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when roomNumber or lengthOfStay is less than or equal to zero.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the room cannot be found or is already occupied.
    /// </exception>
    /// <remarks>
    /// Preconditions:
    /// - roomNumber must be greater than zero
    /// - lengthOfStay must be greater than zero
    /// - room must exist and be available
    /// 
    /// Postconditions:
    /// - A guest is assigned to the specified room
    /// - Room status is updated to occupied
    /// </remarks>
    public void CheckIn(int roomNumber, string name, string phoneNumber, int lengthOfStay);
    /// <summary>
    /// Checks a guest out of a room.
    /// </summary>
    /// <param name="roomNumber">The room number the guest is checking out of.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when roomNumber is less than or equal to zero.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the room cannot be found or is marked as vacant.
    /// </exception>
    /// <remarks>
    /// Preconditions:
    /// - roomNumber must be greater than zero
    /// - room must exist and have an active guest
    /// 
    /// Postconditions:
    /// - Guest is removed from the room
    /// - Room status is updated to available
    /// </remarks>
    public void CheckOut(int roomNumber);

    /// <summary>
    /// Retrieves a list of all rooms that are currently vacant and available for rent.
    /// </summary>
    /// <returns>A list of vacant Room objects.</returns>
    /// <remarks>
    /// Postconditions:
    /// - Returns a list containing only rooms where IsVacant is true.
    /// </remarks>
    public List<Room> GetAvailableRooms();
}