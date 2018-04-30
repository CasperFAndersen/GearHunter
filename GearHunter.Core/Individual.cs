namespace GearHunter.Core
{
    public class Individual : User
    {
        public bool IsValidated { get; set; }

        public Individual()
        {

        }
        public Individual(string name, string address, string zip, string city, string email, string password, string phone, bool isAdmin, bool isActive, bool isValidated) 
            : base(name, address, zip, city, email, password, phone, isAdmin, isActive)
        {
            IsValidated = isValidated;
        }
    }
}
