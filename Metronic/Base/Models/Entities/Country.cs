﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponera.Base.Entities
{
    public class Country:IAuditEntity
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
    }
}
