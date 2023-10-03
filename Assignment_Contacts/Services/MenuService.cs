using Assignment_Contacts.Interfaces;
using Assignment_Contacts.Models;

namespace Assignment_Contacts.Services;

public class MenuService : IMenuService
{
    private IUserInterfaceService _userInterfaceService = new UserInterfaceService();
    private IContactService _contactService = new ContactService();
    public void MainMenu()
    {
        do
        {
            _userInterfaceService.AddHeader("Kontaktlista");
            
            string selection = _userInterfaceService.GetSelectedOption(
                "Lägg till ny kontakt", 
                "Ta bort kontakt", 
                "Se alla kontakter", 
                "Se specifik kontakt", 
                "Avsluta programmet");

            switch (selection)
            {
                case "1":
                    AddContactMenu();
                    break;
                case "2":
                    RemoveContactMenu();
                    break;
                case "3":
                    DisplayAllContactsMenu();
                    break;
                case "4":
                    DisplaySpecificContactMenu();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
            }
        }
        while (true);
    }
    public void AddContactMenu()
    {
        _userInterfaceService.AddHeader("Lägg till kontakt");

        Contact contact = new Contact
        {
            FirstName = _userInterfaceService.GetFieldInput("Förnamn"),
            LastName = _userInterfaceService.GetFieldInput("Efternamn"),
            Email = _userInterfaceService.GetFieldInput("E-postadress"),
            PhoneNumber = _userInterfaceService.GetFieldInput("Telefonnummer"),
            Address = new Address
            {
                StreetAddress = _userInterfaceService.GetFieldInput("Gatuadress"),
                PostalCode  = _userInterfaceService.GetFieldInput("Postkod"),
                City = _userInterfaceService.GetFieldInput("Ort/Stad"),
            }
        };

        _contactService.CreateNewContact(contact);
    }
    public void DisplayAllContactsMenu()
    {
        _userInterfaceService.AddHeader("Alla kontakter");

        var allContacts = _contactService.GetAllContacts();

        if(allContacts == null)
        {
            _userInterfaceService.AddField("Inga kontakter kunde hittas");
            _userInterfaceService.ReadKey();
        }
        else
        {
            _userInterfaceService.AddTableHeader(30, "Namn", "E-post", "Telefonnummer");

            foreach (var contact in _contactService.GetAllContacts())
            {
                _userInterfaceService.AddTableRow(30, contact.FullName, contact.Email, contact.PhoneNumber);
            }

            _userInterfaceService.ReadKey();
        }

        
    }
    public void DisplaySpecificContactMenu()
    {
        _userInterfaceService.AddHeader("Välj kontakt");
        var selectedEmail = _userInterfaceService.GetFieldInput("E-postadress");

        var contact = _contactService.GetContact(selectedEmail);
        if (contact == null)
        {
            _userInterfaceService.AddField($"Kunde inte hitta en kontakt med E-postadress {selectedEmail}");
            _userInterfaceService.ReadKey();
        }
        else
        {
            _userInterfaceService.AddHeader("Kontaktinformation");

            _userInterfaceService.AddTableHeader(40, contact.FullName);

            _userInterfaceService.AddTableRow(40, contact.Email);
            _userInterfaceService.AddTableRow(40, contact.PhoneNumber);
            _userInterfaceService.AddTableRow(40, contact.Address.FullAddress);

            _userInterfaceService.ReadKey();
        }
    }
    public void RemoveContactMenu()
    {
        _userInterfaceService.AddHeader("Välj kontakt att ta bort");

        var selectedEmail = _userInterfaceService.GetFieldInput("E-postadress");

        var isRemoved = _contactService.RemoveContact(selectedEmail);

        if (isRemoved)
        {
            _userInterfaceService.AddField("Kontakten är borttagen");
            _userInterfaceService.ReadKey();
        }
        else
        {
            _userInterfaceService.AddField($"Kunde inte hitta en kontakt med E-postadress {selectedEmail}");
            _userInterfaceService.ReadKey();
        }
    }
}
