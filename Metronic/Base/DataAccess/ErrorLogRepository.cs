using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ponera.Base.DataAccess.Contracts;
using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess
{
    public class ErrorLogRepository : BaseRepository<ErrorLog, int>, IErrorLogRepository
    {
    }
}
