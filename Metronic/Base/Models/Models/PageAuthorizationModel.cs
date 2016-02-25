namespace Ponera.Base.Models
{
    public class PageAuthorizationModel
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int? UserId { get; set; }

        public int? RoleId { get; set; }

        public string Permission { get; set; }
    }
}