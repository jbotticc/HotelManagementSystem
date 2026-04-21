using System.ComponentModel;
using HotelManagementSystem.Domain;

namespace HotelManagementSystem.Contracts;

public interface IUserRepository
{
  public void Add( User user);
  
  public List<User> GetAll();
  public void Update( User user);
  public void Delete( User user);  
}