using System.Configuration;

namespace DataAccessLayer
{
    public class BaseRepository
    {
        protected readonly string _connStr;

        protected BaseRepository()
        {
            _connStr = ConfigurationManager.ConnectionStrings["egitim"].ConnectionString;
        }
    }
}