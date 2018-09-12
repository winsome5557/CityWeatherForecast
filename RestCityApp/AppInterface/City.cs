using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels
{
    [JsonObject]
    public class City
    {
        [Key]
        public string CityName { get; set; }
        public string State { get; set; }
        public string Geographicregion { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public int TouristTating { get; set; }
        public DateTime DateEstablished { get; set; }
        public int EstimatedPopulation { get; set; }

        [NotMapped]
        public Country CountryInformation { get; set; }

        [NotMapped]
        public IList<WeatherForecast> WeatherForecast { get; set; }

    }
}
