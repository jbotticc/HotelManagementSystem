namespace HotelManagementSystem.Domain.Models;

public class SuiteRoom : Room
{
    public SuiteRoom(int roomNumber, int bedCount) : base(roomNumber, bedCount) {}

    public override int Rent => 200;
    public override int Size => 500;
}