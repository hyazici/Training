using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponera.Base.Entities
{
    public class EmailLog : IEntity
    {
        public int Id { get; set; }

        public string FromEmail { get; set; }

        public string ToEmail { get; set; }

        public int? TemplateId { get; set; }

        public string Subject { get; set; }

        public string Result { get; set; }

        public string ErrorMessage { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
