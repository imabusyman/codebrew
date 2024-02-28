using CodeBrew.Maps.Google.GeoCode;
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
            geoCodeAddressBuilder.CreateRequest();
            Assert.IsNotNull(geoCodeAddressBuilder);
        }
    }
}