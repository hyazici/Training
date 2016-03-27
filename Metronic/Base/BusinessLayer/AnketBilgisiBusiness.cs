using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Ponera.Base.BusinessLayer.Extensions;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.Contracts.DataAccess;
using Ponera.Base.Entities;
using Ponera.Base.Models;
using Ponera.Base.ViewModel;

namespace Ponera.Base.BusinessLayer
{
    public class AnketBilgisiBusiness : IAnketBilgisiBusiness
    {
        private readonly IAnketBilgisiRepository _anketBilgisiRepository;

        public AnketBilgisiBusiness(IAnketBilgisiRepository anketBilgisiRepository)
        {
            _anketBilgisiRepository = anketBilgisiRepository;

            Mapper.CreateMap<AnketBilgisi, AnketBilgisiModel>();
            Mapper.CreateMap<AnketBilgisiModel, AnketBilgisi>();
        }


        public DataTableData<AnketBilgisiModel> GetAnketBilgisiByFilter(int start, int length, string search, int sortColumn, string sortDirection)
        {
            IList<PagedEntity<AnketBilgisi>> pagedEntities = _anketBilgisiRepository.GetAllByFilter(start, length, search, sortColumn, sortDirection);

            var pagedInfo = pagedEntities.Any()
                ? pagedEntities.Select(entity => new {entity.RowNumber, entity.TotalDisplayRows, entity.TotalRows})
                    .First()
                : new {RowNumber = 0, TotalDisplayRows = 0, TotalRows = 0};


            DataTableData<AnketBilgisiModel> dataTableData = new DataTableData<AnketBilgisiModel>();

            dataTableData.RecordsFiltered = pagedInfo.TotalDisplayRows;
            dataTableData.RecordsTotal = pagedInfo.TotalRows;

            IEnumerable<AnketBilgisiModel> anketBilgisiModels = pagedEntities.Select(entity => entity.Entity.Map<AnketBilgisiModel>());

            dataTableData.Data = anketBilgisiModels.ToList();

            return dataTableData;
        }
    }
}
