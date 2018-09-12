using AppInterface;
using AppModels;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppInterface
{
    public class CountryService : ICountryService
    {
        #region "Variables"
        private string BaseUrl { get; set; }
        private RestClient restClient { get; set; }
        #endregion

        #region "Constructor"

        public CountryService()
        {
            string baseUrl = ConfigurationManager.AppSettings["countryServiceBaseURL"];
            BaseUrl = baseUrl;
            restClient = new RestClient(baseUrl);
        }

        #endregion

        #region "Public Methods"

        /// <summary>
        /// Get results for all countries
        /// </summary>
        /// <param name="filters">List to specify fields to be included in the result</param>
        /// <returns>List of Country objects</returns>
        public List<Country> GetAllCountries()
        {
            string endPoint = ConfigurationManager.AppSettings["countryServiceAllCounriesEndPoint"];
            var request = new RestRequest(endPoint);
            return GetCountryDataFromService(request);
        }

 
        /// <summary>
        /// Search by Country name. It can be native or partial name.
        /// </summary>
        /// <param name="name">full or partial name</param>
        /// <param name="filters">List to specify fields to be included in the result</param>
        /// <returns>List of Country objects</returns>
        public List<Country> GetByName(string name)
        {
            string endPoint = ConfigurationManager.AppSettings["countryServiceCounryNameEndPoint"];
            endPoint = endPoint + name;
            var request = new RestRequest(endPoint);
            return GetCountryDataFromService(request);
        }


        #endregion

        #region "Private Methods"

        /// <summary>
        /// GetCountryDataFromService
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private List<Country> GetCountryDataFromService(RestRequest request)
        {
            //requestUrl = this.BaseUrl + requestUrl;
            HttpResponseMessage res = null;
            try
            {
                List<Country> countries = null;
                var response = restClient.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string rawResponse = response.Content;
                    countries = JsonConvert.DeserializeObject<List<Country>>(rawResponse);
                    //countries = new JsonDeserializer().Deserialize<List<Country>>(response);
                    return countries;
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

 
         
        #endregion

    }
}
