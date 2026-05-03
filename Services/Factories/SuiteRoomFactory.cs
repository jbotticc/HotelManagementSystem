using HotelManagementSystem.Domain.Factory;
using HotelManagementSystem.Domain.Models;
namespace HotelManagementSystem.Services.Factories;

public class SuiteRoomFactory : RoomFactory
{
    protected override Room CreateRoomInternal(int roomNumber, int bedCount)
    {
        return new SuiteRoom(roomNumber, bedCount);
    }
}