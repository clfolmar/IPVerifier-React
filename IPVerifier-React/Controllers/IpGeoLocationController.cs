using IPVerifier_React.Models;
using IPVerifier_React.Models.ViewModels;
using IPVerifier_React.Repositories;
using IPVerifier_React.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IPVerifier_React.Controllers
{
    public class IpGeoLocationController : Controller
    {
        private IIpGeoLocationService _service;

        public IpGeoLocationController()
        {
            _service = new IpGeoLocationService(ModelState, new IpGeoLocationRepository());
        }

        public IpGeoLocationController(IIpGeoLocationService service)
        {
            _service = service;
        }

        // GET: IpGeoLocation
        public ActionResult Index()
        {
            IpGeoLocationViewModel model = new IpGeoLocationViewModel();

            return View(model);
        }

        // GET: IpGeoLocation
        public async Task<ActionResult> Test()
        {
            IpGeoLocation response = await _service.VerifyIpTest();

            IpGeoLocationViewModel model = new IpGeoLocationViewModel
            {
                AutonomousSystemName = response.IpGeoLocationData.As.Name,
                IsBadIp = false, //TODO: DOUBLE CHECK THIS
                City = response.IpGeoLocationData.City,
                Continent = response.IpGeoLocationData.Continent,
                Country = response.IpGeoLocationData.Country,
                Latitude = response.IpGeoLocationData.Latitude,
                Longitude = response.IpGeoLocationData.Longitude,
                PostalCode = response.IpGeoLocationData.Postal,
                Region = response.IpGeoLocationData.Region,
                ReverseHostName = response.IpGeoLocationData.Hostname,
                TimeZone = response.IpGeoLocationData.Time_Zone
            };

            return View(model);
        }
    }
}