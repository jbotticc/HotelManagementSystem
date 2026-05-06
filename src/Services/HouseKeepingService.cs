using HotelManagementSystem.Contracts;
using HotelManagementSystem.Domain.Models;
using HotelManagementSystem.Domain.Enums;
using TaskStatus = HotelManagementSystem.Domain.Enums.TaskStatus;

namespace HotelManagementSystem.Services;

public class HouseKeepingService : IHouseKeepingService
{
    private readonly IMaintenanceTaskRepository _tasks;
    private readonly IRoomRepository _rooms;

    public HouseKeepingService(IMaintenanceTaskRepository tasks, IRoomRepository rooms)
    {
        _tasks = tasks ?? throw new ArgumentNullException(nameof(tasks));
        _rooms = rooms ?? throw new ArgumentNullException(nameof(rooms));
    }

    public void MarkDone(int roomNumber, int taskNumber)
    {
        if (roomNumber <= 0) throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be positive.");
        
        var tasks = _tasks.GetByRoom(roomNumber);
        if (taskNumber < 0 || taskNumber >= tasks.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(taskNumber), "Task number does not exist for this room.");
        }

        var task = tasks[taskNumber];
        if (task.Status == TaskStatus.Completed)
        {
            throw new InvalidOperationException("Task is already completed.");
        }
        
        task.SetStatus(TaskStatus.Completed);

        _tasks.Update(roomNumber, taskNumber, task);
    }

    public void CreateCleaningTask(int roomNumber, bool isDeepClean)
    {
        if (roomNumber <= 0) throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be positive.");

        // ensure room exists
        _rooms.GetByRoomNumber(roomNumber);

        var task = new CleaningTask(isDeepClean);
        _tasks.Add(roomNumber, task);
    }

    public void CreateRepairTask(int roomNumber, string[] damagedItems)
    {
        if (roomNumber <= 0) throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be positive.");
        if (damagedItems == null || damagedItems.Length == 0) throw new ArgumentException("Damaged items cannot be null or empty.", nameof(damagedItems));
        
        // ensure room exists
        _rooms.GetByRoomNumber(roomNumber);

        var task = new RepairTask(damagedItems);
        _tasks.Add(roomNumber, task);
    }

    public void RemoveTask(int roomNumber, int taskNumber) {
        if (roomNumber <= 0) throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be positive.");

        if (taskNumber < 0) throw new ArgumentOutOfRangeException(nameof(taskNumber), "Task number cannot be negative.");
        
        _tasks.Delete(roomNumber, taskNumber);
    }

    public List<int> GetRoomsWithTasks()
    {
        return _tasks.GetRoomsWithTasks();
    }

    public List<MaintenanceTask> GetTasksForRoom(int roomNumber)
    {
        if (roomNumber <= 0) throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be positive.");
        return _tasks.GetByRoom(roomNumber);
    }
}