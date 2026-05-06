using HotelManagementSystem.Contracts;
using HotelManagementSystem.Domain.Enums;

namespace HotelManagementSystem.Services;

public class LoginService : ILoginService
{
    private readonly IUserRepository _userRepository;
    private int? _loggedIn;

    public LoginService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public void Login(int employeeId)
    {
        if (_loggedIn != null)
        {
            throw new InvalidOperationException("A user is already logged in");
        }

        _userRepository.GetByEmployeeId(employeeId);
        _loggedIn = employeeId;
    }

    public void Logout()
    {
        if (_loggedIn == null)
        {
            throw new InvalidOperationException("No user logged in.");
        }
        
        _loggedIn = null;
    }

    public bool IsLoggedIn()
    {
        return _loggedIn != null;
    }

    public Role GetCurrentUserRole()
    {
        if (_loggedIn == null)
        {
            throw new InvalidOperationException("No user logged in.");
        }

        return _userRepository.GetByEmployeeId(_loggedIn.Value).Role;
    }
}