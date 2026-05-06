namespace HotelManagementSystem.Domain.Models;

public class StandardRoom : Room
{
    public StandardRoom(int roomNumber) : base(roomNumber, 1) { }
    
    public override string ToString()
    {
        return $"Room {RoomNumber} (Standard) - Beds: {BedCount}, Base Rent: ${Rent}";
    }
}