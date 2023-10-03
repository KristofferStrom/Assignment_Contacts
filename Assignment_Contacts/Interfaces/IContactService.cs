using Assignment_Contacts.Models;

namespace Assignment_Contacts.Interfaces
{
    public interface IContactService
    {
        IContact CreateNewContact(Contact contact);
        List<Contact> GetAllContacts();
        IContact GetContact(string email);
        bool RemoveContact(string email);
    }
}
