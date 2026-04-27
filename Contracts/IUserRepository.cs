using System.ComponentModel;
using HotelManagementSystem.Domain;

namespace HotelManagementSystem.Contracts;

public interface IUserRepository
{
    /// <summary>
    /// Adds a new user to the repository.
    /// </summary>
    /// <param name="user">The user to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when the user is null.</exception>
    /// <remarks>
    /// Preconditions:
    /// - user must not be null
    /// Postconditions:
    /// - User is added to the repository
  public void Add( User user);
  
  /// <summary>
    /// Retrieves all users from the repository.
    /// </summary>
    /// <returns>A list of all users.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the user is null.</exception>
    /// <remarks>
    /// Preconditions:    
    /// - Repository must contain users
    /// Postconditions:
    /// - Returns a list of all users in the repository
    /// </remarks>
  public List<User> GetAll();
  
  /// <summary>
    /// Updates an existing user's information in the repository.
    /// </summary>
    /// <param name="user">The user with updated information.</param>
    /// <exception cref="ArgumentNullException">Thrown when the user is null.</exception>
    /// <remarks>
    /// Preconditions:
    /// - user must not be null
    /// Postconditions:
    /// - User information is updated in the repository
    /// </remarks>
  public void Update( User user);

  /// <summary>
    /// Removes a user from the repository.
    /// </summary>
    /// <param name="user">The user to remove.</param>
    /// <exception cref="ArgumentNullException">Thrown when the user is null.</exception>
    /// <remarks>
    /// Preconditions:
    /// - user must not be null
    /// Postconditions:
    /// - User is removed from the repository
    /// </remarks>
  public void Delete( User user);  
}