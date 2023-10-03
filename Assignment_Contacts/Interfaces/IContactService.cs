namespace Assignment_Contacts.Interfaces
{
    public interface IContactService
    {
        IContact CreateNewContact(IContact contact);
        List<IContact> GetAllContacts();
        IContact GetContact(string email);
        bool RemoveContact(string email);
    }
}
