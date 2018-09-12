using AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInterfaces
{
    public interface ICityRepository : IDisposable
    {
        IEnumerable<City> GetCities();
        City GetCityByName(string Name);
        void InsertCity(City City);
        void DeleteCity(string Name);
        void UpdateCity(City City);
        void Save();
    }
}
