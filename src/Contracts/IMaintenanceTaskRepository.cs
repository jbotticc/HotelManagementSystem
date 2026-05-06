using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Contracts;

/// <summary>
/// Defines the contract for a repository that manages maintenance tasks for hotel rooms.
/// </summary>
public interface IMaintenanceTaskRepository
{
    /// <summary>
    /// Adds a new maintenance task for a specific room.
    /// </summary>
    /// <param name="roomNumber">The unique number identifying the room.</param>
    /// <param name="task">The maintenance task to be added.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="task"/> is null.</exception>
    /// <remarks>
    /// Preconditions: The <paramref name="task"/> must not be null, and <paramref name="roomNumber"/> must be a valid room identifier.
    /// Postconditions: The task is successfully stored and associated with the specified room.
    /// </remarks>
    void Add(int roomNumber, MaintenanceTask task);

    /// <summary>
    /// Retrieves all maintenance tasks associated with a specific room.
    /// </summary>
    /// <param name="roomNumber">The unique number identifying the room.</param>
    /// <returns>A list of maintenance tasks for the given room.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when the <paramref name="roomNumber"/> is not found.</exception>
    /// <remarks>
    /// Preconditions: The <paramref name="roomNumber"/> must exist in the repository.
    /// Postconditions: Returns a list containing all tasks for the room. Throws <see cref="KeyNotFoundException"/> if the room is not found.
    /// </remarks>
    List<MaintenanceTask> GetByRoom(int roomNumber);

    /// <summary>
    /// Updates an existing maintenance task for a specific room.
    /// </summary>
    /// <param name="roomNumber">The unique number identifying the room.</param>
    /// <param name="taskNumber">The index or identifier of the task within the room's task list.</param>
    /// <param name="task">The updated task information.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="task"/> is null.</exception>
    /// <exception cref="KeyNotFoundException">Thrown when the <paramref name="roomNumber"/> or <paramref name="taskNumber"/> is not found.</exception>
    /// <remarks>
    /// Preconditions: Both <paramref name="roomNumber"/> and <paramref name="taskNumber"/> must exist in the repository, and <paramref name="task"/> must not be null.
    /// Postconditions: The specified task is updated with the new information.
    /// </remarks>
    void Update(int roomNumber, int taskNumber, MaintenanceTask task);

    /// <summary>
    /// Deletes a specific maintenance task from a room's task list.
    /// </summary>
    /// <param name="roomNumber">The unique number identifying the room.</param>
    /// <param name="taskNumber">The index or identifier of the task to be removed.</param>
    /// <exception cref="KeyNotFoundException">Thrown when the <paramref name="roomNumber"/> or <paramref name="taskNumber"/> is not found.</exception>
    /// <remarks>
    /// Preconditions: Both <paramref name="roomNumber"/> and <paramref name="taskNumber"/> must exist in the repository.
    /// Postconditions: The specified task is removed from the room's task list.
    /// </remarks>
    void Delete(int roomNumber, int taskNumber);
    
    /// <summary>
    /// Retrieves all rooms that have maintenance tasks.
    /// </summary>
    /// <returns>A list of room numbers that have maintenance tasks.</returns>
    /// <remarks>
    /// Postconditions: Returns a list containing all room numbers that have maintenance tasks.
    /// </remarks>
    List<int> GetRoomsWithTasks();
}
