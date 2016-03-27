using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ponera.Base.ViewModel
{
    public class DataTableData<TModel>
    {
        [JsonProperty("draw")]
        public int Draw { get; set; }

        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }

        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get; set; }

        [JsonProperty("data")]
        public List<TModel> Data { get; set; }
    }
}
