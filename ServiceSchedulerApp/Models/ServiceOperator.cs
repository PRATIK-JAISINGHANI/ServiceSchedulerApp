using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSchedulerApp.Models
{
    public class ServiceOperator : BaseClass
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public float GeoLatitude { get; set; }

        public float GeoLongitude { get; set; }
    }
}
