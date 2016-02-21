using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponera.Base.Entities
{
    public class MenuAuthorization : IEntity
    {
        public int Id { get; set; }

        public int MenuId { get; set; }

        public int? UserId { get; set; }

        public int? RoleId { get; set; }

        public bool SavePermission { get; set; }

        public bool ReadPermission { get; set; }

        public bool DeletePermission { get; set; }

        public DateTime CreateDate { get; set; }

        public int CreateUserId { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? UpdateUserId { get; set; }

        public bool Deleted { get; set; }
    }
}
