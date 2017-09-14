using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClasses.Models
{
    public class OlympicEvent
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int SportId { get; set; }
    }
}
