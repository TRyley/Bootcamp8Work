using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClasses
{
    public class Athlete
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CountryName { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Sex { get; set; }
        public DateTime DOB { get; set; }
        public int HomeTownId { get; set; }
    }
}
