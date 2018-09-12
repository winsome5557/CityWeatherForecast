
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels
{

    [JsonObject]
    public class Country
    {
        [Key]
        public string Name { get; set; }
        public string[] TopLevelDomain { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string[] CallingCodes { get; set; }
        public string Capital { get; set; }
        public string[] AltSpellings { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public int Population { get; set; }
        public float[] Latlng { get; set; }
        public string Demonym { get; set; }
        public float Area { get; set; }
        public float Gini { get; set; }
        public string[] Timezones { get; set; }
        public string[] Borders { get; set; }
        public string NativeName { get; set; }
        public string NumericCode { get; set; }
        public Currency[] Currencies { get; set; }
        public Language[] Languages { get; set; }
        public Translations Translations { get; set; }
        public string Flag { get; set; }
        public Regionalbloc[] RegionalBlocs { get; set; }
        public string Cioc { get; set; }
    }

    [JsonObject]
    public class Translations
    {
        public string De { get; set; }
        public string Es { get; set; }
        public string Fr { get; set; }
        public string Ja { get; set; }
        public string It { get; set; }
        public string Br { get; set; }
        public string Pt { get; set; }
        public string Nl { get; set; }
        public string Hr { get; set; }
        public string Fa { get; set; }
    }

    [JsonObject]
    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
    [JsonObject]
    public class Language
    {
        public string Iso639_1 { get; set; }
        public string Iso639_2 { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
    }

    [JsonObject]
    public class Regionalbloc
    {
        public string Acronym { get; set; }
        public string Name { get; set; }
        public object[] OtherAcronyms { get; set; }
        public object[] OtherNames { get; set; }
    }

    public static class Filters
    {
        public const string Name = "name";
        public const string TopLevelDomain = "topLevelDomain";
        public const string Alpha2Code = "alpha2code";
        public const string Alpha3Code = "alpha3code";
        public const string CallingCodes = "callingCodes";
        public const string Capital = "capital";
        public const string AltSpellings = "altSpellings";
        public const string Region = "region";
        public const string Subregion = "subregion";
        public const string Population = "population";
        public const string Latlng = "latlng";
        public const string Demonym = "demonym";
        public const string Area = "area";
        public const string Gini = "gini";
        public const string Timezones = "timezones";
        public const string Borders = "borders";
        public const string NativeName = "nativeName";
        public const string NumericCode = "numericCode";
        public const string Currencies = "currencies";
        public const string Languages = "languages";
        public const string Translations = "translations";
        public const string Flag = "flag";
        public const string RegionalBlocs = "regionalBlocs";
        public const string Cioc = "cioc";
    }
}
