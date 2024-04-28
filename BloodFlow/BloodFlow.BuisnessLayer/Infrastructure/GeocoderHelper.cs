using BloodFlow.BuisnessLayer.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodFlow.BuisnessLayer.Validation;

namespace BloodFlow.BuisnessLayer.Infrastructure
{
    public static class GeocoderHelper
    {
        private static string apiKey = "d54f116a499649478e2dfa51bda2291a";

        public static async Task<Dictionary<string, double>> GeocodeAddress(AddressModel address)
        {
            string fullAddress = $"{address.HouseNumber} {address.StreetName}, {address.CityName}";
            string requestUri = $"https://api.opencagedata.com/geocode/v1/json?q={Uri.EscapeDataString(fullAddress)}&key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(json);
                    var results = jsonObject["results"];

                    if (results.HasValues)
                    {
                        double latValue = (double)results[0]["geometry"]["lat"];
                        double lngValue = (double)results[0]["geometry"]["lng"];

                        return new Dictionary<string, double> { { "Latitude", latValue }, { "Longitude", lngValue } };
                    }
                    else
                    {
                        throw new ValidationException("Address not found.");
                    }
                }
                else
                {
                    throw new ValidationException("Failed to retrieve data from API.");
                }
            }
        }
    }
}
