using System.Collections.Generic;
using Ponera.Base.Entities;
using Ponera.Base.Models;
using Ponera.Base.ViewModel;

namespace Ponera.Base.Contracts.BusinessLayer
{
    public interface IAnketBilgisiBusiness
    {
        DataTableData<AnketBilgisiModel> GetAnketBilgisiByFilter(int start, int length, string search, int sortColumn, string sortDirection);
    }
}