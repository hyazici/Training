﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ponera.Base.Models
{
    [Serializable]
    public class UserModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        // TODO : @deniz passwordler encyrept edilecek 
        public string Password { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        [JsonIgnore]
        public IList<RoleModel> Roles { get; set; }
    }
}
