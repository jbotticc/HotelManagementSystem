namespace HotelManagementSystem.Domain;

public struct Guest
{
    private string _name;
    private string _phoneNumber;


    private DateTime _checkoutDate;

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
        set 
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Guest name cannot be null or empty.");

            _name = value;
        }
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set 
         {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Phone number cannot be null or empty.");

            _phoneNumber = value;
        }
    }

    public DateTime CheckoutDate
    {
        get => _checkoutDate;
        set => _checkoutDate = value;
    }


}