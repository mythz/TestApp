using NUnit.Framework;
using ServiceStack;
using TestApp.ServiceModel;

namespace TestApp.Tests
{
    [TestFixture]
    public class SoapTests
    {
        [Test]
        public void Can_call_GetDevices_with_Soap12ServiceClient()
        {
            var client = new Soap12ServiceClient("http://localhost:49488/");

            var response = client.Send(new GetDevices());
        }
    }
}
