using AppInterface;
using AppInterfaces;
using AppModels;
using AppRepositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppInterface
{
    public class CityService : ICityService
    {
        #region "Variables"
        private ICityRepository repository { get; set; }
        #endregion

        #region "Constructor"

        public CityService(ICityRepository repo )
        {
            repository = repo;
        }

        #endregion

        #region "Public Methods"

        public IEnumerable<City> GetCities()
        {
            return repository.GetCities(); 
        }

        public City GetCityByName(string Name)
        {
            City c = repository.GetCityByName(Name);
            return repository.GetCityByName(Name);
        }
        public void InsertCity(City City)
        {
            repository.InsertCity(City);
        }
        public void DeleteCity(string Name)
        {
            repository.DeleteCity(Name);
        }

        public void UpdateCity(City city)
        {
            repository.UpdateCity(city);
        }

        public void Save()
        {
            repository.Save();
        }


        #endregion
    }
}
