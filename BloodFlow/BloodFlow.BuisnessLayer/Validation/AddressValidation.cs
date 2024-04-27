using BloodFlow.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;

namespace BloodFlow.BuisnessLayer.Validation
{
    public static class AddressValidation
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task ValidateAddress(AddressModel address)
        {
            BaseValidation.IsObjectNull(address, nameof(address));
            BaseValidation.IsWhiteSpaceOrNullOrEmpty(address.CityName);
            BaseValidation.IsWhiteSpaceOrNullOrEmpty(address.StreetName);
            BaseValidation.IsObjectNull(address.HouseNumber, nameof(address.HouseNumber));

            await IsAddressExists(address.CityName, address.StreetName, address.HouseNumber);
        }

        private static async Task IsAddressExists(string cityName, string streetName, int houseNumber)
        {
            string apiKey = "d54f116a499649478e2dfa51bda2291a";
            string fullAddress = $"{streetName} {houseNumber}, {cityName}";
            string url = $"https://api.opencagedata.com/geocode/v1/json?q={Uri.EscapeDataString(fullAddress)}&key={apiKey}";

            HttpResponseMessage response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to reach geocoding service.");
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            JObject data = JObject.Parse(responseBody);
            if (data["total_results"] == null || (int)data["total_results"] == 0)
            {
                throw new InvalidAddressException("The specified full address does not exist.");
            }
        }
    }
}
