using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClasses.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string IocCountryCode { get; set; }
        public string Iso2c { get; set; }
        public string Iso3c { get; set; }
        public decimal GdpPerCapita { get; set; }
        public decimal LifeExpectancy { get; set; }
        public int Population { get; set; }
        public int RegionId { get; set; }
        public int IncomeId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
