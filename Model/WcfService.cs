using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WcfService
    {
        public string ServiceId { get; set; }

        public string ServiceName { get; set; }

        public bool ServiceStatus { get; set; }

        public bool IsRunNow { get; set; }

        public ServiceType Type { get; set; }
    }
}
