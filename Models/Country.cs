using System;
using System.Collections.Generic;

namespace Zad7.Models
{
    public partial class Country
    {
        public Country()
        {
            CountryTrips = new HashSet<CountryTrip>();
        }

        public int IdCountry { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CountryTrip> CountryTrips  { get; set; }
    }
}
