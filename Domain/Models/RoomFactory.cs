namespace HotelManagementSystem.Domain.Models;

public abstract class RoomFactory
{
    public Room CreateRoom(int roomNumber, int bedCount)
    {
        if (roomNumber <= 0)
        {
            throw new ArgumentException("Room number must be positive");
        }
        if (bedCount <= 0)
        {
            throw new ArgumentException("Bed count must be positive");
        }
        
        return CreateRoomInternal(roomNumber, bedCount);
    }
    
    protected abstract Room CreateRoomInternal(int roomNumber, int bedCount);
}