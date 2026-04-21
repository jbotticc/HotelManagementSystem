using HotelManagementSystem.Domain;

namespace HotelManagementSystem.Contracts;

public interface IGuestRepository
{
    public void Add(Guest guest);
    public Guest GetByRoom(int roomNumber);
    public void Update(Guest guest);
    public void Delete(Guest guest);

}