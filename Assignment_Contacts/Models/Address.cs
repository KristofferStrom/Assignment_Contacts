using Assignment_Contacts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Contacts.Models
{
    public class Address : IAddress
    {
        public string StreetAddress { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

        public string FullAddress => $"{StreetAddress}, {PostalCode}, {City.ToUpper()}";
    }
}
