namespace HotelManagementSystem.Domain.Models;

public class CleaningTask : MaintenanceTask
{
    public bool IsDeepClean { get; }

    public CleaningTask(bool isDeepClean) {
        IsDeepClean = isDeepClean;
    }

    public override string ToString() {
        return "Cleaning Task" + "\n" + "Deep Clean: " + IsDeepClean + "\n" + "Status: " + Status;
    }

}