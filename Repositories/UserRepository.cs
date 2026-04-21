using System.Reflection.Metadata;
using HotelManagementSystem.Domain;

namespace HotelManagementSystem.Repositories;

public class UserRepository: Contracts.IUserRepository 
{
    private List<User> _users = new List<User>();
    private static UserRepository _instance;

    private UserRepository(){}
    public static UserRepository GetInstance()
    {
        if (_instance == null)
        {
            _instance = new UserRepository();
        }
        return _instance;
    }
        public void Add(User user)
    {
        _users.Add(user);
    }

    public List<User> GetAll()
    {
        return new List<User>(_users);
    }

    public void Update(User user)
    {
        var existingUser = _users.FirstOrDefault(u => u.EmployeeId == user.EmployeeId);
        if (existingUser != null)
        {
            _users.Remove(existingUser);
            _users.Add(user);
        }
    }

    public void Delete(User user)
    {
        _users.Remove(user);
    }
}