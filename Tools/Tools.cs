using System.Data.SqlClient;
using System.Data;
using wsSanMartin.Data;

namespace wsSanMartin
{
    public class Tools
    {
        public static DataTable ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(Conection.connection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                DataTable dataTable = new DataTable();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }

                return dataTable;
            }
        }
    }
}