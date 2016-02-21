namespace Ponera.Base.Models
{
    public class MenuAuthorizationModel
    {
        public int Id { get; set; }

        public int MenuId { get; set; }

        public int? UserId { get; set; }

        public int? RoleId { get; set; }

        public bool SavePermission { get; set; }

        public bool ReadPermission { get; set; }

        public bool DeletePermission { get; set; }
    }
}