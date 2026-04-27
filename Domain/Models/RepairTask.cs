namespace HotelManagementSystem.Domain.Models;

public class RepairTask : MaintenanceTask
{
    public string[] DamagedItems { get; }

    public RepairTask(string[] damagedItems) {
        if (damagedItems.Length == 0) {
            throw new ArgumentException("Cannot create a repair task with no damaged items.");
        }

        DamagedItems = damagedItems;
    }

    public override string ToString() {
        return "Repair Task: " + String.Join(", ", DamagedItems) + "\n" + "Status: " + _status;
    }
}