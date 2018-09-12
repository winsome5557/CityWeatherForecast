using AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInterfaces
{
    public interface IWeatherForecastService
    {
        List<WeatherForecast> GetByCityName(String cityName, String country);
    }
}
