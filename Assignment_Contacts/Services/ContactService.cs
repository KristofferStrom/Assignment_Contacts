using Assignment_Contacts.Interfaces;
using Assignment_Contacts.Models;

namespace Assignment_Contacts.Services;

public class ContactService : IContactService
{
    List<IContact> _contacts = new List<IContact>
    {
        new Contact
        {
            FirstName = "Kristoffer",
            LastName = "Ström",
            Email = "kristoffer.strom@hotmail.se",
            PhoneNumber = "1234567890",
            Address = new Address
            {
                StreetAddress = "Gubbängsvägen 90",
                PostalCode = "12345",
                City = "Enskede",
            }
        },
        new Contact
        {
            FirstName = "Kalle",
            LastName = "Ström",
            Email = "kalle.strom@hotmail.com",
            PhoneNumber = "1234522855",
            Address = new Address
            {
                StreetAddress = "Ringvägen 30",
                PostalCode = "12445",
                City = "Stockholm",
            }
        }

    };
    public IContact CreateNewContact(IContact contact)
    {
        _contacts.Add(contact);
        return contact;
    }

    public List<IContact> GetAllContacts()
    {
        if (_contacts.Count == 0)
            return null!;

        return _contacts;
    }

    public IContact GetContact(string email)
    {
        var contact = _contacts.FirstOrDefault(contact => contact.Email == email);
        if (contact == null)
            return null!;

        return contact;
    }

    public bool RemoveContact(string email)
    {
        var contactToRemove = _contacts.FirstOrDefault(contact => contact.Email == email);

        if(contactToRemove == null)
            return false;
        
        _contacts.Remove(contactToRemove);
        return true;
    }
}
