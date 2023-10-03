using System.Net;

namespace Assignment_Contacts.Interfaces
{
    public interface IContact
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        IAddress Address { get; set; }
        string FullName { get;}
    }
}
