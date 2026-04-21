namespace HotelManagementSystem.Domain.Models;

public class StandardRoom : Room
{
    public StandardRoom(int roomNumber) : base(roomNumber, 1) {}
}