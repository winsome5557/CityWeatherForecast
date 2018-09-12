using AppInterfaces;
using AppModels;
using AppUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppInterface
{
    public class WeatherForecastService : IWeatherForecastService
    {

        #region "Variables"
        private string BaseUrl { get; set; }
        private RestClient restClient { get; set; }

        private string apiKey { get; set; }
        #endregion

        #region "Constructor"

        public WeatherForecastService()
        {
            string baseUrl = ConfigurationManager.AppSettings["weatherServiceBaseURL"];
            BaseUrl = baseUrl;
            apiKey = ConfigurationManager.AppSettings["weatherServiceKey"];
            restClient = new RestClient(baseUrl);
        }

        #endregion

        /// <summary>
        ///     Get the forecast for a specific city by indicating the city and country names.
        /// </summary>
        /// <param name="city">Name of the city.</param>
        /// <param name="country">Country of the city.</param>
        /// <returns> The forecast information.</returns>
        public List<WeatherForecast> GetByCityName(String city, String country)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(city) || String.IsNullOrEmpty(country))
                    throw new Exception("City and/or Country cannot be empty.");

                //var request = new RestRequest(endPoint);
                string weatherServiceCityEndPoint = ConfigurationManager.AppSettings["weatherServiceCityAndcountryEndPoint"];
                string cityForecastEndPoint = ConfigurationManager.AppSettings["weatherServiceCityAndcountryEndPoint"];
                string cityForecastAPIKey = ConfigurationManager.AppSettings["weatherServiceKey"];
                var request = new RestRequest(cityForecastEndPoint + city + "," + country+ "&appid="+ cityForecastAPIKey);
                return GetWeatherDataFromRemoteService(request);
               // var response = ApiClient.GetResponse("/forecast?q=" + city + "," + country);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// GetWeatherDataFromRemoteService
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private List<WeatherForecast> GetWeatherDataFromRemoteService(RestRequest request)
        {
            //requestUrl = this.BaseUrl + requestUrl;
            HttpResponseMessage res = null;
            try
            {
                List<WeatherForecast> forecast = null;
                var response = restClient.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string rawResponse = response.Content;
                    var parsedResponse = JObject.Parse(rawResponse);
                    forecast = WeatherDeserializer.GetWeatherForecast(parsedResponse);
                    //countries = new JsonDeserializer().Deserialize<List<Country>>(response);
                    return forecast;
                }

                else
                {
                    throw new HttpRequestException("Invalid Response code, API didn't respond with status code 200.");
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (res != null) res.Dispose();
            }
        }
       }
    
}
