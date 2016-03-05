using System.Collections.Generic;
using Ponera.Base.Models;

namespace Ponera.Base.Contracts.BusinessLayer
{
    public interface ICountryBusiness
    {
        void AddCountry(CountryModel countryModel);

        void DeleteCountry(int countryId);

        CountryModel GetCountryById(int id);

        IList<CountryModel> GetCountrys();

        void UpdateCountry(CountryModel countryModel);
    }
}