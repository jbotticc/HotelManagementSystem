namespace HotelManagementSystem.Domain.Models;

public class SuiteRoom : Room
{
    public SuiteRoom(int roomNumber, int bedCount) : base(roomNumber, bedCount) {}

    public override int Rent => 200;
    public override int Size => 500;

    public override string ToString()
    {
        return $"Room {RoomNumber} (Suite) - Beds: {BedCount}, Base Rent: ${Rent}";
    }
}