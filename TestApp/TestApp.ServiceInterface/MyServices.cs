using ServiceStack;
using TestApp.ServiceModel;

namespace TestApp.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(GetDevices request)
        {
            return new GetDevicesResponse();
        }
    }
}