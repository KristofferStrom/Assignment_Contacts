namespace Assignment_Contacts.Interfaces;

public interface IAddress
{
    string StreetAddress { get; set; }
    string City { get; set; }
    string PostalCode { get; set; }
    string FullAddress { get; }
}
