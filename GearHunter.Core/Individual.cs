namespace GearHunter.Core
{
    public class Individual : User
    {

        public Individual()
        {

        }
        public Individual(int id, string name, string address, string zip, string city, string email, string password, string phone, bool isAdmin, bool isActive) 
            : base(id, name, address, zip, city, email, password, phone, isAdmin, isActive)
        {
        }
    }
}
