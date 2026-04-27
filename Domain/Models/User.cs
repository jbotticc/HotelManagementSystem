using HotelManagementSystem.Domain.Enums;
namespace HotelManagementSystem.Domain.Models;

public class User
{
    public User(int employeeId, Role role)
    {
        if (employeeId <= 0)
            throw new ArgumentException("Employee ID must be a positive integer.");

        if (!Enum.IsDefined(typeof(Role), role))
            throw new ArgumentException("Invalid role value.");

        EmployeeId = employeeId;
        Role = role;
    }

    public int EmployeeId { get; }

    public Role Role { get; private set; }

    public void ChangeRole(Role newRole)
    {
        if (!Enum.IsDefined(typeof(Role), newRole))
            throw new ArgumentException("Invalid role value.");

        Role = newRole;
    }
}