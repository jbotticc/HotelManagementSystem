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
            set => _employeeId = value;
        }

        public Role Role
        {
            get => _role;
            set => _role = value;
        }
}