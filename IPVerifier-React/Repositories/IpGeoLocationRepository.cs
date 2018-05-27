using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using IPVerifier_React.Models;
using Newtonsoft.Json;

namespace IPVerifier_React.Repositories
{
    public class IpGeoLocationRepository : IIpGeoLocationRepsitory
    {

        public async Task<IpGeoLocation> VerifyIp(string ip)
        {
            string apiKey = ConfigurationManager.AppSettings["ApilityApiKey"],
                ipCheckUrl = ConfigurationManager.AppSettings["IpCheckUrl"] + ip + "?token=" + apiKey,
                geoIpLookupUrl = ConfigurationManager.AppSettings["GeoLookupUrl"] + ip + "?token=" + apiKey;

            IpGeoLocation info = new IpGeoLocation();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ipCheckUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(ipCheckUrl);

                if (response.IsSuccessStatusCode)
                {

                    //JsonConvert.PopulateObject(response, info);
                }
                else
                {

                }

            }

            return null;
        }

        public async Task<IpGeoLocation> VerifyIpTest()
        {
            // Retrieve data from file
            string path = HostingEnvironment.MapPath("~\\App_Data\\data.json");

            using (StreamReader r = new StreamReader(path))
            {
                string data = await r.ReadToEndAsync();

                if (!String.IsNullOrEmpty(data))
                {

                    RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(data);
                    IpGeoLocation ipGeoLocation = new IpGeoLocation();
                    ipGeoLocation.IpGeoLocationData = rootObject.Ip;
                    ipGeoLocation.BadIp = false; // TODO: since results it's not a bad ip?

                    if (String.IsNullOrEmpty(rootObject.Ip.Latitude.ToString()))
                    {
                        Console.WriteLine("ERROR");
                    }
                    else
                    {
                        Console.WriteLine();

                        return ipGeoLocation;
                    }
                }
                r.Close();
            }

            // oops
            return null;
        }
    }

    public interface IIpGeoLocationRepsitory
    {
        Task<IpGeoLocation> VerifyIp(string ip);
        Task<IpGeoLocation> VerifyIpTest();
    }
}