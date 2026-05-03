using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Contracts;

public interface IRoomRepository
{
    /// <summary>
    /// A method to add a new room to the room repository
    /// </summary>
    /// <param name="room">The room to be added</param>
    /// <exception cref="InvalidOperationException">Thrown when a room already exists with the provided Room Number</exception>
    void Add(Room room);

    /// <summary>
    /// A method to retrieve a list of all rooms
    /// </summary>
    /// <returns>A list of all rooms currently in the repository</returns>
    IReadOnlyList<Room> GetAll();
    
    /// <summary>
    /// A method to retrieve one room given a room number
    /// </summary>
    /// <param name="roomNumber">The Room Number of the room to retrieve</param>
    /// <returns>A room object</returns>
    /// <exception cref="InvalidOperationException">Thrown when a room does not already exist with the provided Room Number</exception>
    Room GetByRoomNumber(int roomNumber);
    
    /// <summary>
    /// A method to update a room already in the repository
    /// </summary>
    /// <param name="room">The new room to replace the old room identified by its Room Number</param>
    /// <exception cref="InvalidOperationException">Thrown when a room does not already exist with the provided Room Number</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - A room must exist with the Room Number stored in the <see cref="room"/> parameter
    /// 
    /// Post-conditions:
    /// - The room object with the Room Number of the given room is replaced with the provided room object
    /// </remarks>
    void Update(Room room);
    
    /// <summary>
    /// A method to delete a room already in the repository
    /// </summary>
    /// <param name="roomNumber">The Room Number of the room to delete</param>
    /// <exception cref="InvalidOperationException">Thrown when the <see cref="roomNumber"/> does not match an existing room</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - A room must exist with the Room Number provided
    /// 
    /// Post-conditions:
    /// - The room object with the provided Room Number is deleted
    /// </remarks>
    void Delete(int roomNumber);
}