using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using ServiceStack;

namespace TestApp.ServiceModel
{
    [Route("/api/device")]
    [DataContract]
    public class GetDevices : IReturn<GetDevicesResponse>
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class GetDevicesResponse { }
}