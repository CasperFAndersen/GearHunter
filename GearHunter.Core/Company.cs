namespace GearHunter.Core
{
    public class Company : User
    {
        public string CVR { get; set; }
        public Company()
        {

        }
        public Company(int id, string name, string address, string zip, string city, string email, string password, string phone, bool isAdmin, bool isActive, string cvr) 
            : base(id, name, address, zip, city, email, password, phone, isAdmin, isActive)
        {
            CVR = cvr;
        }
    }



}
