using System.ComponentModel;
using HotelManagementSystem.Domain;

namespace HotelManagementSystem.Contracts;

public interface IUserRepository
{
    /// <summary>
    /// Adds a new user to the repository.
    /// </summary>
    /// <param name="user">The user to add.</param>
  public void Add( User user);
  
  /// <summary>
    /// Retrieves all users from the repository.
    /// </summary>
    /// <returns>A list of all users.</returns>
  public List<User> GetAll();
  
  /// <summary>
    /// Updates an existing user's information in the repository.
    /// </summary>
    /// <param name="user">The user with updated information.</param>
  public void Update( User user);

  /// <summary>
    /// Removes a user from the repository.
    /// </summary>
    /// <param name="user">The user to remove.</param>
  public void Delete( User user);  
}