namespace HotelManagementSystem.Domain.Models;

public abstract class MaintenanceTask
{
    private TaskStatus _status = TaskStatus.Incomplete;

    public void SetStatus(TaskStatus status)
    {
        _status = status;
    }

    public abstract string ToString();
}   