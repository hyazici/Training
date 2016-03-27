using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoneraAdmin.Views.Templates.Models
{
    public class GridTemplateModel
    {
        public object Model { get; set; }

        public IList<string> DisplayColumns { get; set; }

        public IList<string> DisplayColumnNames { get; set; }

        public string DataTableTitle { get; set; }

        public IList<string> ColumnOrders { get; set; }

        public bool Sortable { get; set; }
    }
}