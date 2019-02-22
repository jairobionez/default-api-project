using DefaultProject.Domain.Entities.Base;
using DefaultProject.Domain.ValueObjects;

namespace DefaultProject.Domain.Entities
{
    public class User : EntityBase
    {
        public User(Name name, Address address)
        {
            Name = name;
            Address = address;

            AddNotifications(Name, Address);
        }

        public User()
        {

        }

        public Name Name { get;  set; }

        public Address Address { get; set; }

        public string FullName()
        {
            return this.Name.FirstName + " " + this.Name.LastName;
        }
    }
}
