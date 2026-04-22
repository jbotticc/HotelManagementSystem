namespace HotelManagementSystem.Domain;

public struct Guest
{
    private string _name;
    private string _phoneNumber;


    private DateTime _checkoutDate;

    public Guest(string name, string phoneNumber, DateTime checkoutDate)
    {
        _name = name;
        _phoneNumber = phoneNumber;
        _checkoutDate = checkoutDate;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set => _phoneNumber = value;
    }

    public DateTime CheckoutDate
    {
        get => _checkoutDate;
        set => _checkoutDate = value;
    }


}