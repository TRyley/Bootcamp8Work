using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClasses.Models
{
    public class AthleteMedal
    {
        public int AthleteId { get; set; }
        public int MedalId { get; set; }
        public decimal MedalCount { get; set; }
    }
}
