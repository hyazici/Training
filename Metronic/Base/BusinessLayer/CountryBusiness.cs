using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ponera.Base.BusinessLayer.Extensions;
using Ponera.Base.DataAccess;
using Ponera.Base.Entities;
using Ponera.Base.Models;

namespace Ponera.Base.BusinessLayer
{
    public class CountryBusiness
    {
        private readonly CountryRepository _countryRepository;

        public CountryBusiness()
        {
            _countryRepository = new CountryRepository();

            // TODO : @deniz Buradaki mapping işlemleri bunu yönetecek ayrı bir class'a taşınacak.
            Mapper.CreateMap<Country, CountryModel>();
            Mapper.CreateMap<CountryModel, Country>();
        }

        public IList<CountryModel> GetCountrys()
        {
            IList<Country> countrys = _countryRepository.GetAll(false);

            IList<CountryModel> countryModels = countrys.Select(country => Mapper.Map<Country, CountryModel>(country)).ToList();

            return countryModels;
        }

        public void AddCountry(CountryModel countryModel)
        {
            if (countryModel == null)
            {
                throw new ArgumentException(nameof(countryModel));
            }

            Contract.Requires(!string.IsNullOrEmpty(countryModel.CountryName));

            Country country = Mapper.Map<CountryModel, Country>(countryModel);

            country.CreateDate = DateTime.Now;
            country.CreateUserId = 0; // TODO : Bu alana hangi user işlem yaptıysa eklenecek.

            _countryRepository.Add(country);

            countryModel.Id = country.Id;
        }

        public void UpdateCountry(CountryModel countryModel)
        {
            if (countryModel == null)
            {
                throw new ArgumentNullException(nameof(countryModel));
            }

            Contract.Requires(!string.IsNullOrEmpty(countryModel.CountryName));
            Contract.Requires(countryModel.Id > 0);

            Country country = _countryRepository.GetById(countryModel.Id);

            if (country == null)
            {
                // TODO : throw exception
            }

            country.CountryName = countryModel.CountryName;
            UpdateCountry(country);

            countryModel.Id = country.Id;
        }

        public void DeleteCountry(int countryId)
        {
            Country country = _countryRepository.GetById(countryId);

            country.Deleted = true;
            country.UpdateDate = DateTime.Now;
            country.UpdateUserId = 0;

            _countryRepository.Update(country);
        }

        public CountryModel GetCountryById(int id)
        {
            if (id == 0)
            {
                // TODO : exception fırlat
            }

            Country country = _countryRepository.GetById(id);

            CountryModel countryModel = country.Map<CountryModel>();

            return countryModel;
        }

        private void UpdateCountry(Country country)
        {
            country.UpdateDate = DateTime.Now;
            country.UpdateUserId = 0;

            _countryRepository.Update(country);
        }
    }
}
