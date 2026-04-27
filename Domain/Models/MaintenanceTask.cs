namespace HotelManagementSystem.Domain.Models;
using HotelManagementSystem.Domain.Enums;

public abstract class MaintenanceTask
{
    protected TaskStatus Status = TaskStatus.Incomplete;

    public void SetStatus(TaskStatus status)
    {
        Status = status;
    }

    public abstract string ToString();
}   