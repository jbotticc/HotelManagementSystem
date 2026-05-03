namespace HotelManagementSystem.Domain.Models;
using HotelManagementSystem.Domain.Enums;

public abstract class MaintenanceTask
{
    private TaskStatus _status = TaskStatus.Incomplete;

    public TaskStatus Status => _status;

    public void SetStatus(TaskStatus status)
    {
        _status = status;
    }

    public abstract override string ToString();
}   