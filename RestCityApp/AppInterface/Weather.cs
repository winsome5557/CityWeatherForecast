using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels
{
    /// <summary>
    ///     General weather result type
    /// </summary>
    public abstract class Weather
    {
        /// <summary>
        ///     Time of data receiving in GMT.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     City name.
        /// </summary>
        /// 
        [Key, Column(Order = 0)]
        public String City { get; set; }

        /// <summary>
        ///     Country name.
        /// </summary>
        /// 
        [Key, Column(Order = 1)]
        public String Country { get; set; }


        /// <summary>
        ///     City identifier.
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        ///     Weather title.
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        ///     Weather description.
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        ///     Temperature in Kelvin.
        /// </summary>
        public Double Temp { get; set; }

        /// <summary>
        ///     Humidity in %
        /// </summary>
        public Double Humidity { get; set; }

        /// <summary>
        ///     Maximum temperature in Kelvin.
        /// </summary>
        public Double TempMax { get; set; }

        /// <summary>
        ///     Minimum temperature in Kelvin.
        /// </summary>
        public Double TempMin { get; set; }

        /// <summary>
        ///     Wind speed in mps.
        /// </summary>
        public Double WindSpeed { get; set; }

        /// <summary>
        ///     Icon name.
        /// </summary>
        public String Icon { get; set; }

        /// <summary>
        ///     The condition ID.
        /// </summary>
        public int ConditionID { get; set; }
    }

    /// <summary>
    ///     WeatherCurrent weather result type.
    /// </summary>
    public class WeatherCurrent : Weather
    {
    }
    /// <summary>
    ///     WeatherDaily forecast result type.
    /// </summary>
    public class WeatherDaily : Weather
    {
        /// <summary>
        ///     Temperature in the morning in Kelvin.
        /// </summary>
        public Double TempMorning { get; set; }

        /// <summary>
        ///     Temperature in the evening in Kelvin.
        /// </summary>
        public Double TempEvening { get; set; }

        /// <summary>
        ///     Temperature at night in Kelvin.
        /// </summary>
        public Double TempNight { get; set; }

        /// <summary>
        ///     Atmospheric pressure in hPa.
        /// </summary>
        public Double Pressure { get; set; }

        /// <summary>
        ///     Precipitation volume mm per 3 hours.
        /// </summary>
        public Double Rain { get; set; }

        /// <summary>
        ///     Time of data receiving in unixtime GMT.
        /// </summary>
        public int DateUnixFormat { get; set; }

        /// <summary>
        ///     Cloudiness in %
        /// </summary>
        public Double Clouds { get; set; }
    }

    /// <summary>
    ///     WeatherForecast result type.
    /// </summary>
    public class WeatherForecast : Weather
    {
        /// <summary>
        ///     Time of data receiving in unixtime GMT.
        /// </summary>
        public int DateUnixFormat { get; set; }

        /// <summary>
        ///     Cloudiness in %
        /// </summary>
        public Double Clouds { get; set; }
    }

}
