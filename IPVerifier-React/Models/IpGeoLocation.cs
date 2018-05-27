using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPVerifier_React.Models
{
    public class IpGeoLocation
    {
        public Ip IpGeoLocationData { get; set; }
        public bool BadIp { get; set; }
    }

    public class RegionNames
    {
    }

    public class As
    {
        public List<string> Networks { get; set; }
        public string Name { get; set; }
        public string Asn { get; set; }
        public string Country { get; set; }
    }

    public class CountryNames
    {
        public string En { get; set; }
        public string __invalid_name__pt_BR { get; set; }
        public string Fr { get; set; }
        public string Ja { get; set; }
        public string De { get; set; }
        public string __invalid_name__zh_CN { get; set; }
        public string Es { get; set; }
        public string Ru { get; set; }
    }

    public class CityNames
    {
    }

    public class ContinentNames
    {
        public string En { get; set; }
        public string __invalid_name__pt_BR { get; set; }
        public string Fr { get; set; }
        public string Ja { get; set; }
        public string De { get; set; }
        public string __invalid_name__zh_CN { get; set; }
        public string Es { get; set; }
        public string Ru { get; set; }
    }

    public class Ip
    {
        public string Time_Zone { get; set; }
        public string City { get; set; }
        public int Continent_Geoname_Id { get; set; }
        public string Region { get; set; }
        public int Accuracy_Radius { get; set; }
        public string Latitude { get; set; }
        public int Region_Geoname_Id { get; set; }
        public RegionNames Region_Names { get; set; }
        public string Postal { get; set; }
        public string Longitude { get; set; }
        public As As { get; set; }
        public string Address { get; set; }
        public string Continent { get; set; }
        public CountryNames Country_Names { get; set; }
        public CityNames City_Names { get; set; }
        public string Hostname { get; set; }
        public int Country_Geoname_Id { get; set; }
        public string Country { get; set; }
        public ContinentNames Continent_Names { get; set; }
        public int City_Geoname_Id { get; set; }
    }

    public class RootObject
    {
        public Ip Ip { get; set; }
    }
}