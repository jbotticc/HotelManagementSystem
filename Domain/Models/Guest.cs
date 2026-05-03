namespace HotelManagementSystem.Domain.Models;

public struct Guest
{
    private readonly string _name;
    private readonly string _phoneNumber;

    private readonly DateTime _checkoutDate;

    public Guest(string name, string phoneNumber, DateTime checkoutDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Guest name cannot be null or empty.");

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number cannot be null or empty.");
  
        _name = name;
        _phoneNumber = phoneNumber;
        _checkoutDate = checkoutDate;
    }

    public string Name
    {
        get => _name;
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
    }

    public DateTime CheckoutDate
    {
        get => _checkoutDate;
    }


}