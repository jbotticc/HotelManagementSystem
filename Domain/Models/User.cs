using HotelManagementSystem.Domain.Enums;

namespace HotelManagementSystem.Domain;

public class User
{
    private string _employeeId;
    private Role _role;

    public User(string employeeId, Role role)
    {
        _employeeId = employeeId;
        _role = role;
    }

        public string EmployeeId
        {
            get => _employeeId;
        }

        public Role Role
        {
            get => _role;
            set => _role = value;
        }

        public void changeRole(Role newRole)
        {
            _role = newRole;
        }
}