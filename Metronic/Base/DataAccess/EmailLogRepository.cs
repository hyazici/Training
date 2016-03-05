using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ponera.Base.Contracts.DataAccess;
using Ponera.Base.Entities;

namespace Ponera.Base.DataAccess
{
    public class EmailLogRepository : BaseRepository<EmailLog, int>, IEmailLogRepository
    {
    }
}
