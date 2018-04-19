namespace GearHunter.Core
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool isValidated { get; set; }

        public User()
        {

        }

        public User(string name, string address, string zip, string city, string email, string password, string phone, bool isAdmin, bool isActive)
        {
            Name = name;
            Address = address;
            Zip = zip;
            City = city;
            Email = email;
            Password = password;
            Phone = phone;
            IsAdmin = isAdmin;
            IsActive = isActive;
            isValidated = false;
        }

        public User(int id, string name, string address, string zip, string city, string email, string password, string phone, bool isAdmin, bool isActive)
        {
            Id = id; 
            Name = name;
            Address = address;
            Zip = zip;
            City = city;
            Email = email;
            Password = password;
            Phone = phone;
            IsAdmin = isAdmin;
            IsActive = isActive;
            isValidated = false;
        }
    }
}
