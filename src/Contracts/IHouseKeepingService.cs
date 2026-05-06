using System.Collections.Generic;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Contracts;
/// <summary>
/// Defines the contract for a service that manages housekeeping operations and maintenance tasks.
/// </summary>
public interface IHouseKeepingService
{
    /// <summary>
    /// Marks a specific maintenance task as completed for a given room.
    /// </summary>
    /// <param name="roomNumber">The unique number identifying the room.</param>
    /// <param name="taskNumber">The index or identifier of the task within the room's task list.</param>
    /// <exception cref="KeyNotFoundException">Thrown when the <paramref name="roomNumber"/> is not found.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="roomNumber"/> is not positive or the <paramref name="taskNumber"/> is out of range.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the task is already completed.</exception>
    /// <remarks>
    /// Preconditions: Both <paramref name="roomNumber"/> and <paramref name="taskNumber"/> must exist.
    /// Postconditions: The specified task's status is updated to completed.
    /// </remarks>
    void MarkDone(int roomNumber, int taskNumber);

    /// <summary>
    /// Creates a new cleaning task for a specific room.
    /// </summary>
    /// <param name="roomNumber">The unique number identifying the room.</param>
    /// <param name="isDeepClean">A boolean indicating whether the room requires a deep clean.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="roomNumber"/> is not positive.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the room does not exist.</exception>
    /// <remarks>
    /// Preconditions: The <paramref name="roomNumber"/> must be a valid room identifier.
    /// Postconditions: A cleaning task is created and associated with the room.
    /// </remarks>
    void CreateCleaningTask(int roomNumber, bool isDeepClean);

    /// <summary>
    /// Creates a new repair task for a specific room with a list of damaged items.
    /// </summary>
    /// <param name="roomNumber">The unique number identifying the room.</param>
    /// <param name="damagedItems">An array of strings representing the items that need repair.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="roomNumber"/> is not positive.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="damagedItems"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="damagedItems"/> is empty.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the room does not exist.</exception>
    /// <remarks>
    /// Preconditions: The <paramref name="roomNumber"/> must be a valid room identifier, and <paramref name="damagedItems"/> must not be empty.
    /// Postconditions: A repair task is created and associated with the room.
    /// </remarks>
    void CreateRepairTask(int roomNumber, string[] damagedItems);

    /// <summary>
    /// Retrieves a list of room numbers that currently have maintenance tasks.
    /// </summary>
    /// <returns>A list of room numbers that have maintenance tasks.</returns>
    /// <remarks>
    /// Postconditions: Returns a list containing all room numbers that have maintenance tasks.
    /// </remarks>
    List<int> GetRoomsWithTasks();

    /// <summary>
    /// Retrieves all maintenance tasks associated with a specific room.
    /// </summary>
    /// <param name="roomNumber">The unique number identifying the room.</param>
    /// <returns>A list of maintenance tasks for the given room.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when the <paramref name="roomNumber"/> is not found.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="roomNumber"/> is not positive.</exception>
    /// <remarks>
    /// Preconditions: The <paramref name="roomNumber"/> must exist in the repository.
    /// Postconditions: Returns a list containing all tasks for the room. Throws <see cref="KeyNotFoundException"/> if the room is not found.
    /// </remarks>
    List<MaintenanceTask> GetTasksForRoom(int roomNumber);

    /// <summary>
    /// Removes a task from a specific room.
    /// </summary>
    /// <param name="roomNumber">The unique number identifying the room.</param>
    /// <param name="taskNumber">The index or identifier of the task to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="roomNumber"/> is not positive or the <paramref name="taskNumber"/> is out of range.</exception>
    /// <exception cref="KeyNotFoundException">Thrown when the room is not found.</exception>
    /// <remarks>
    /// Preconditions: Both <paramref name="roomNumber"/> and <paramref name="taskNumber"/> must exist.
    /// Postconditions: The specified task is removed from the room.
    /// </remarks>
    void RemoveTask(int roomNumber, int taskNumber);
}