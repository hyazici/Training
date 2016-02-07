using System;
using System.ComponentModel;

namespace Ponera.Base.Models
{
    public class RoleModel
    {
        public int Id { get; set; }

        [DisplayName("Rol Adı")]
        public string RoleName { get; set; }
    }
}