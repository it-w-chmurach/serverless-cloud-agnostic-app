using OrderService.Domain.SharedKernel;

namespace OrderService.Domain.Models
{
    public class Address : ValueObject
    {
        private Address(string country, string city, string postalCode, string addressLine)
        {
            Country = country;
            City = city;
            PostalCode = postalCode;
            AddressLine = addressLine;
        }

        public string Country { get; }
        public string City { get; }
        public string PostalCode { get; }
        public string AddressLine { get; }

        public static Address Create(string country, string city, string postalCode, string addressLine)
            => new(country, city, postalCode, addressLine);
    }
}