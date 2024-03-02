using Bogus;
using CodeBrew.Common.Models;
using CodeBrew.Maps.Google.GeoCode;
using CodeBrew.Maps.Google.Models;
using Microsoft.Extensions.Logging;
using Moq;

namespace CodeBrew.Maps.Google.Tests
{
    [TestClass]
    public class GeoCodeAddressBuilderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCreateGeoCodeAddressBuilderError()
        {
            var logger = new Mock<ILogger<GeoCodeAddressBuilder>>();
            var geoCodeAddressBuilder = new GeoCodeAddressBuilder(logger.Object);
            Assert.IsNotNull(geoCodeAddressBuilder);
            var request = geoCodeAddressBuilder.CreateRequest();
        }

        [TestMethod]
        public void TestCreateGeoCodeAddressBuilder()
        {
            var logger = new Mock<ILogger<GeoCodeAddressBuilder>>();
            var geoCodeAddressBuilder = new GeoCodeAddressBuilder(logger.Object);
            Assert.IsNotNull(geoCodeAddressBuilder);
            var googleAddress = CreateGoogleAddress();
            geoCodeAddressBuilder.WithAddress(googleAddress);
            geoCodeAddressBuilder.WithApiKey("testKey");
            var request = geoCodeAddressBuilder.CreateRequest();
            Assert.IsNotNull(request);
        }

        private GoogleAddress CreateGoogleAddress()
        {
            return new GoogleAddressFaker().Generate();
        }
    }
    public sealed class GoogleAddressFaker : Faker<GoogleAddress>
    {
        public GoogleAddressFaker()
        {
            RuleFor(o => o.Street, f => f.Address.StreetAddress());
            RuleFor(o => o.City, f => f.Address.City());
            RuleFor(o => o.State, f => new State(f.PickRandom<StateEnum>()));
            RuleFor(o => o.PostalCode, f => f.Address.ZipCode("#####"));
            RuleFor(o => o.Country, f => f.Address.Country());
            RuleFor(o => o.PlusFour, f => f.Address.ZipCode("####"));
        }
    }
}