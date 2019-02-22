using DefaultProject.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace DefaultProject.Domain.ValueObjects
{
    public class Name : ValueObject
    {

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo 3 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome deve conter até 40 caracteres")
           );
        }

        public Name()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
