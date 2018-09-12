using AppInterfaces;
using AppModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRepositories
{
    public class CityRepository : ICityRepository, IDisposable
    {
        private CitiesContext context;

        public CityRepository(CitiesContext context)
        {
            this.context = context;
        }

        public IEnumerable<City> GetCities()
        {
            return context.Cities.ToList();
        }

        public City GetCityByName(string Name)
        {
            return context.Cities.Find(Name);
        }

        public void InsertCity(City City)
        {
            context.Cities.Add(City);
        }

        public void DeleteCity(string Name)
        {
            City City = context.Cities.Find(Name);
            context.Cities.Remove(City);
        }

        public void UpdateCity(City City)
        {
            context.Entry(City).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public class CitiesContext : DbContext
    {

        public CitiesContext() : base("CitiesContext")
        {
            Database.SetInitializer<CitiesContext>(new CreateDatabaseIfNotExists<CitiesContext>());
        }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
