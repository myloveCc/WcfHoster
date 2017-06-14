using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Result
    {
        public string ServiceId { get; set; }

        public bool IsSuccess { get; set; }

        public IEnumerable<string> Messages { get; set; }
    }
}
