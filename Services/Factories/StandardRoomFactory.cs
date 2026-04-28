using HotelManagementSystem.Domain.Models;
namespace HotelManagementSystem.Services.Factories;

public class StandardRoomFactory : RoomFactory
{
    protected override Room CreateRoomInternal(int roomNumber, int bedCount)
    {
        return new StandardRoom(roomNumber);
    }
}