namespace HotelManagementSystem.Domain.Models;

public abstract class Room
{
    public int RoomNumber { get; }
    public int BedCount { get; }
    public bool IsVacant { get; private set; }
    public virtual int Rent => 100;
    public virtual int Size => 300;

    protected Room(int roomNumber, int bedCount)
    {
        RoomNumber = roomNumber;
        BedCount = bedCount;
        IsVacant = true;
    }

    public void MarkOccupied()
    {
        if (!IsVacant)
        {
            throw new InvalidOperationException("Room is already occupied");
        }
        IsVacant = false;
    }

    public void MarkVacant()
    {
        if (IsVacant)
        {
            throw new InvalidOperationException("Room is already vacant");
        }
        IsVacant = true;
    }
}