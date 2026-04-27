using HotelManagementSystem.Domain.Models;
namespace HotelManagementSystem.Contracts;

public interface IUserRepository
{
    /// <summary>
    /// Adds a new user to the repository.
    /// </summary>
    /// <param name="user">The user to add.</param>
    /// <exception cref="InvalidOperationException">Thrown when the user is null.</exception>
    /// <remarks>
    /// Preconditions:
    /// - User must not be null
    /// Postconditions:
    /// - User is added to the repository
    /// </remarks>
    void Add(User user);
  
    /// <summary>
    /// Retrieves all users from the repository.
    /// </summary>
    /// <returns>A list of all users.</returns>
    List<User> GetAll();
  
    /// <summary>
    /// A method to retrieve a User from the repository given their employeeId
    /// </summary>
    /// <param name="employeeId">The employeeId of the user to retrieve</param>
    /// <exception cref="InvalidOperationException">Thrown when a user does not exist with the provided employeeId</exception>
    /// <returns>
    /// The User object with the provided employeeId
    /// </returns>
    /// <remarks>
    /// Pre-conditions:
    /// - A user must exist with the provided employeeId
    ///
    /// Post-conditions:
    /// - The user object identified by the provided employeeId is returned
    /// </remarks>
    User GetByEmployeeId(int employeeId);
    
    /// <summary>
    /// Updates an existing user's information in the repository.
    /// </summary>
    /// <param name="user">The user with updated information.</param>
    /// <exception cref="InvalidOperationException">Thrown when the user is null.</exception>
    /// <remarks>
    /// Preconditions:
    /// - user must not be null
    /// Postconditions:
    /// - User information is updated in the repository
    /// </remarks>
    void Update(User user);

    /// <summary>
    /// Removes a user from the repository.
    /// </summary>
    /// <param name="user">The user to remove.</param>
    /// <exception cref="InvalidOperationException">Thrown when the user is null.</exception>
    /// <remarks>
    /// Preconditions:
    /// - user must not be null
    /// Postconditions:
    /// - User is removed from the repository
    /// </remarks>
    void Delete(User user);  
}