using System.Text.Json.Serialization;

namespace CodeBrew.Common.Models
{
    public abstract class Address
    {
        #region Protected Constructors

        protected Address()
        {
        }

        protected Address(string address, string city, State state, string postalCode, string country)
        {
            Street = address ?? throw new ArgumentNullException(nameof(address));
            City = city ?? throw new ArgumentNullException(nameof(city));
            State = state;
            PostalCode = postalCode ?? throw new ArgumentNullException(nameof(postalCode));
            Country = country ?? throw new ArgumentNullException(nameof(country));
        }

        #endregion Protected Constructors

        // Create an address class that has city, country, postal code, state, street, street2, street3, coordinate, zip code, and plus four

        #region Public Properties

        public string? City { get; set; }
        public Coordinate? Coordinate { get; set; }
        public string? Country { get; set; }

        [JsonIgnore]
        public string FormattedAddress => $"{Street}, {City}, {State}, {PostalCode}, {Country}";

        public string? PlusFour { get; set; }
        public string? PostalCode { get; set; }
        public State? State { get; set; }
        public string? Street { get; set; }
        public string? Street2 { get; set; }
        public string? Street3 { get; set; }
        public string? ZipCode { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override string ToString()
        {
            return $"{FormattedAddress}";
        }

        #endregion Public Methods
    }
}