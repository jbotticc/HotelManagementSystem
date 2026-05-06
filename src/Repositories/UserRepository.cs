using HotelManagementSystem.Domain.Models;
using HotelManagementSystem.Contracts;
namespace HotelManagementSystem.Repositories;

public class UserRepository: IUserRepository 
{
    private readonly List<User> _users = new();
    private static readonly UserRepository _instance = new();

    private UserRepository(){}
    
    public static UserRepository GetInstance()
    {
        return _instance;
    }
    
    public int GetNextUserId()
    {
        return _users.Count + 1;
    }
    
    public void Add(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        
        if (_users.Any(u => u.EmployeeId == user.EmployeeId))
            throw new InvalidOperationException("User with this employee ID already exists.");

        _users.Add(user);
    }
    
    public List<User> GetAll()
    {
        return new List<User>(_users);
    }

    public User GetByEmployeeId(int employeeId)
    {
        var user = _users.FirstOrDefault(u => u.EmployeeId == employeeId);

        if (user == null)
            throw new InvalidOperationException("User not found.");

        return user;
    }

    public void Update(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        
        var index = _users.FindIndex(u => u.EmployeeId == user.EmployeeId);

        if (index == -1)
            throw new InvalidOperationException("User not found.");

        _users[index] = user;
    }

    public void Delete(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        
        var removedCount = _users.RemoveAll(u => u.EmployeeId == user.EmployeeId);

        if (removedCount == 0)
            throw new InvalidOperationException("User not found.");
    }
}