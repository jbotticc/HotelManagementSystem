using HotelManagementSystem.Domain.Factory;
using HotelManagementSystem.Domain.Models;
using HotelManagementSystem.Domain.Enums;

namespace HotelManagementSystem.Contracts;

public interface IManagerService
{

    /// <summary>
    /// A method to retrieve the number of rooms that are currently occupied
    /// </summary>
    /// <returns>
    /// An integer value which is the total number of rooms with the "isVacant" attribute set to false
    /// </returns>
    int ViewOccupancy();
    
    /// <summary>
    /// A method to create a room given a factory object
    /// </summary>
    /// <param name="factory">The factory of the room to create</param>
    /// <param name="roomNumber">The room number of the room</param>
    /// <param name="bedCount">The number of beds the room will have</param>
    /// <exception cref="ArgumentNullException">Thrown when the factory is null</exception>
    void CreateRoom(RoomFactory factory, int roomNumber, int bedCount);
    
    /// <summary>
    /// A method to create a new User in the system with an auto-generated employee ID
    /// </summary>
    /// <param name="role">The role to assign to the new user</param>
    /// <returns>The newly created User object</returns>
    User AddUser(Role role);

    /// <summary>
    /// A method to set the pricing strategy for the hotel
    /// </summary>
    /// <param name="strategy">The pricing strategy to set</param>
    /// <exception cref="ArgumentNullException">Thrown when the strategy is null</exception>
    void SetPricingStrategy(IPricingStrategy strategy);
}