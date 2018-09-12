using AppInterface;
using AppInterfaces;
using AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppCityAPI.Controllers
{
    public class CityController : ApiController
    {
        private ICityService CityService;
        private ICountryService CountryService;
        private IWeatherForecastService WeatherService;

        public CityController(ICityService cityService, ICountryService ctService, IWeatherForecastService wService)
        {
            this.CityService = cityService;
            this.CountryService = ctService;
            this.WeatherService = wService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<City> GetCities()
        {
            return CityService.GetCities();
        }

        [HttpGet]
        public City Get(string name)
        {
            try
            {
                City c = CityService.GetCityByName(name);
                if (c != null)
                {
                    // Get weather forecast and country information
                    IList<WeatherForecast> forecast = WeatherService.GetByCityName(name, c.CountryCode);
                    IList<Country> countryInfoList = CountryService.GetByName(c.CountryName);
                    c.CountryInformation = countryInfoList.FirstOrDefault();
                    c.WeatherForecast = forecast;
                }
                else
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("No city found with Name = {0}", name)),
                        ReasonPhrase = "City Not Found"
                    };
                    throw new HttpResponseException(resp);
                }
                return c;
            }
            catch(Exception exp)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format("Internal Server Error = {0}", exp)),
                    ReasonPhrase = "Error when processing"
                };
                throw new HttpResponseException(resp);
            }
        }

 
        [HttpPost]
        public IHttpActionResult Post([FromBody]City value)
        {
            try
            {
                if (value == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("Invalid json data suplied")),
                        ReasonPhrase = "Invalid json data suplied"
                    };
                throw new HttpResponseException(resp);
                }

                CityService.InsertCity(value);
                return Ok();
            }
            catch (Exception exp)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format("Internal Server Error = {0}", exp)),
                    ReasonPhrase = "Error when processing"
                };
                throw new HttpResponseException(resp);
            }

        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]City value)
        {
            try
            {
                if (value == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("Invalid json data suplied")),
                        ReasonPhrase = "Invalid json data suplied"
                    };
                    throw new HttpResponseException(resp);
                }

                CityService.UpdateCity(value);
                return Ok();
            }
            catch (Exception exp)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format("Internal Server Error = {0}", exp)),
                    ReasonPhrase = "Error when processing"
                };
                throw new HttpResponseException(resp);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(string Name)
        {
            try
            {
                CityService.DeleteCity(Name);
                return Ok();
            }
            catch (Exception exp)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format("Internal Server Error = {0}", exp)),
                    ReasonPhrase = "Error when processing"
                };
                throw new HttpResponseException(resp);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


    }
}

