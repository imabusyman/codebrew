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
            geoCodeAddressBuilder.CreateRequest();
        }

        [TestMethod]
        public void TestCreateGeoCodeAddressBuilder()
        {
            var logger = new Mock<ILogger<GeoCodeAddressBuilder>>();
            var geoCodeAddressBuilder = new GeoCodeAddressBuilder(logger.Object);
            Assert.IsNotNull(geoCodeAddressBuilder);
            var googleAddress = CreateGoogleAddress(true);
            geoCodeAddressBuilder.WithAddress(googleAddress);
            geoCodeAddressBuilder.WithApiKey("testKey");
            GeoCodeAddressRequest request = geoCodeAddressBuilder.CreateRequest();
            Assert.IsNotNull(request);
            Assert.IsNotNull(request.GoogleAddress);
            Assert.IsTrue(request.FormattedUrl().Contains("key"));
            Assert.IsTrue(request.FormattedUrl().Contains("address"));
            Assert.IsTrue(request.FormattedUrl().Contains("json"));
        }

        [TestMethod]
        public void TestCreateGeoCodeCheckAddressBuilder()
        {
            var logger = new Mock<ILogger<GeoCodeAddressBuilder>>();
            var geoCodeAddressBuilder = new GeoCodeAddressBuilder(logger.Object);
            Assert.IsNotNull(geoCodeAddressBuilder);
            var googleAddress = CreateGoogleAddress(false);
            geoCodeAddressBuilder.WithAddress(googleAddress);
            geoCodeAddressBuilder.WithApiKey("testKey");
            var request = geoCodeAddressBuilder.CreateRequest();
            Assert.IsNotNull(request);

            Assert.AreEqual(request.GoogleAddress?.FormattedAddress, "91 Windmill St, Piedmont, OK, 73078, USA");
        }

        private GoogleAddress CreateGoogleAddress(bool useFake = true)
        {
            if (useFake)
            {
                return new GoogleAddressFaker().Generate();
            }
            else
            {
                return new GoogleAddress
                {
                    Street = "91 Windmill St",
                    City = "Piedmont",
                    State = new State(StateEnum.Oklahoma),
                    PostalCode = "73078",
                    Country = "USA"
                };
            }
        }
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
