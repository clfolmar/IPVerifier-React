using IPVerifier_React.Models;
using IPVerifier_React.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IPVerifier_React.Services
{
    public class IpGeoLocationService : IIpGeoLocationService
    {

        private ModelStateDictionary _modelState;
        private IIpGeoLocationRepsitory _repository;

        public IpGeoLocationService(ModelStateDictionary modelState, IpGeoLocationRepository repository)
        {
            _modelState = modelState;
            _repository = repository;
        }

        protected bool ValidateIp(string ip)
        {
            string ipRegexPattern = ConfigurationManager.AppSettings["IpRegexPattern"];

            if (System.Text.RegularExpressions.Regex.IsMatch(ip, ipRegexPattern) &&
                long.TryParse(ip.Replace(".", "").Trim(), out long n))
            {
                return true;
            }

            return false;
        }

        public async Task<IpGeoLocation> VerifyIp(string ip)
        {
            // Validation logic
            if (!ValidateIp(ip))
                return null;

            // Data Access Logic
            try
            {
                return await _repository.VerifyIp(ip);
            }
            catch
            {
                // oops
                return null;
            }

        }

        public async Task<IpGeoLocation> VerifyIpTest()
        {
            // Data Access Logic
            try
            {
                return await _repository.VerifyIpTest();
            }
            catch
            {
                // oops
                return null;
            }

        }
    }

    public interface IIpGeoLocationService
    {
        Task<IpGeoLocation> VerifyIp(string ip);
        Task<IpGeoLocation> VerifyIpTest();
    }
}