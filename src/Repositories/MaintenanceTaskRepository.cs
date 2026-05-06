using HotelManagementSystem.Contracts;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Repositories;

public class MaintenanceTaskRepository : IMaintenanceTaskRepository
{
    private Dictionary<int, List<MaintenanceTask>> _maintenanceTasks = [];

    private static readonly MaintenanceTaskRepository _instance = new();
    
    public static MaintenanceTaskRepository GetInstance() {
        return _instance;
    }

    public void Add(int roomNumber, MaintenanceTask task) {
        if (task == null) throw new ArgumentNullException(nameof(task));
        
        if (_maintenanceTasks.ContainsKey(roomNumber)) {
            _maintenanceTasks[roomNumber].Add(task);
        } else {
            var list = new List<MaintenanceTask>();
            list.Add(task);
            _maintenanceTasks.Add(roomNumber, list);
        }
    }

    public List<MaintenanceTask> GetByRoom(int roomNumber) {
        if (_maintenanceTasks.ContainsKey(roomNumber)) {
            return _maintenanceTasks[roomNumber];
        } else {
            throw new KeyNotFoundException("Room number not found.");
        }
    }

    public void Update(int roomNumber, int taskNumber, MaintenanceTask task) {
        if (task == null) throw new ArgumentNullException(nameof(task));

        if (_maintenanceTasks.ContainsKey(roomNumber)) {
            var list = _maintenanceTasks[roomNumber];
            if (taskNumber >= 0 && taskNumber < list.Count) {
                list[taskNumber] = task;
            } else {
                throw new KeyNotFoundException("Task number not found.");
            }
        } else {
            throw new KeyNotFoundException("Room number not found.");
        }
    }

    public void Delete(int roomNumber, int taskNumber) {
        if (_maintenanceTasks.ContainsKey(roomNumber)) {
            var list = _maintenanceTasks[roomNumber];
            if (taskNumber >= 0 && taskNumber < list.Count) {
                list.RemoveAt(taskNumber);
                if (list.Count == 0) {
                    _maintenanceTasks.Remove(roomNumber);
                }
            } else {
                throw new KeyNotFoundException("Task number not found.");
            }
        } else {
            throw new KeyNotFoundException("Room number not found.");
        }
    }

    public List<int> GetRoomsWithTasks() {
        return new List<int>(_maintenanceTasks.Keys);
    }
}
