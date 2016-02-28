using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponera.Base.Entities
{
    public class ErrorLog : IEntity
    {
        public int Id { get; set; }

        public Guid HandlingInstanceId { get; set; }

        public string ExceptionType { get; set; }

        public string ExceptionDetail { get; set; }

        public string PageName { get; set; }

        public int UserId { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
