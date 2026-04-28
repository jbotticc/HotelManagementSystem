using HotelManagementSystem.Domain.Enums;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Contracts;

public interface ILoginService
{
    /// <summary>
    /// Logs a user into the system using their employee ID.
    /// </summary>
    /// <param name="employeeId">The unique identifier of the user attempting to log in.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when a user with the given employee ID does not exist 
    /// or when another user is already logged in.
    /// </exception>
    /// <remarks>
    /// Pre-conditions:
    /// - The employeeId must correspond to an existing user
    /// - No user is currently logged in
    ///
    /// Post-conditions:
    /// - The specified user is set as the currently logged-in user
    /// </remarks>
    void Login(int employeeId);
    
    /// <summary>
    /// Logs the currently logged-in user out of the system.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when there is no user currently logged in.
    /// </exception>
    /// <remarks>
    /// Pre-conditions:
    /// - A user must be logged in
    ///
    /// Post-conditions:
    /// - No user remains logged in
    /// </remarks>
    void Logout();
    
    /// <summary>
    /// Determines whether a user is currently logged in.
    /// </summary>
    /// <returns>
    /// True if a user is logged in; otherwise, false.
    /// </returns>
    bool IsLoggedIn();
    
    /// <summary>
    /// Gets the role of the currently logged-in user.
    /// </summary>
    /// <returns>
    /// The role used to determine which console menu options are available.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when no user is currently logged in.
    /// </exception>
    Role GetCurrentUserRole();
}