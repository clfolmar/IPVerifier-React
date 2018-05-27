using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPVerifier_React.Models.ViewModels
{
    public class IpGeoLocationViewModel
    {
        public bool IsBadIp { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string AutonomousSystemName { get; set; }
        public string ReverseHostName { get; set; }
        public string TimeZone { get; set; }
    }
}