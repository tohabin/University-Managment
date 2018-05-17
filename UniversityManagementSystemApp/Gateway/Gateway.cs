using System.Data.SqlClient;
using System.Web.Configuration;

namespace UniversityManagementSystemApp.Gateway
{
    public class Gateway
    {
        public string connectionString = WebConfigurationManager.ConnectionStrings["UMS_DB"].ConnectionString;
        public SqlConnection Connection { get; set; }
        public string Query { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }

        public Gateway()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}