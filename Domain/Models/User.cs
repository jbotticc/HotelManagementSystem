using HotelManagementSystem.Domain.Enums;

namespace HotelManagementSystem.Domain;

public class User
{
    private string _employeeId;
    private Role _role;

    public User(string employeeId, Role role)
    {
            if (string.IsNullOrWhiteSpace(employeeId))
        {
            throw new ArgumentException("Employee ID cannot be null or empty.");
        }
    
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
        set
        {
            if (!Enum.IsDefined(typeof(Role), value))
            {
                throw new ArgumentException("Invalid role value.");
            }

            _role = value;
        }        }

        public void changeRole(Role newRole)
        {
            _role = newRole;
        }
}