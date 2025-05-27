public class User
{
    // Attributes
    public string FullName { get; set; }
    public string NIC { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    // Default (parameterless) constructor
    public User()
    {
        FullName = string.Empty;
        NIC = string.Empty;
        PhoneNumber = 0;
        Email = string.Empty;
        Username = string.Empty;
        Password = string.Empty;
    }

    // Parameterized constructor
    public User(string fullName, string nic, int phoneNumber, string email, string username, string password)
    {
        FullName = fullName;
        NIC = nic;
        PhoneNumber = phoneNumber;
        Email = email;
        Username = username;
        Password = password;
    }

    // Methods
    public bool Login(string username, string password)
    {
        return Username == username && Password == password;
    }

    public void Logout()
    {
        Console.WriteLine($"{Username} has logged out.");
    }
}
