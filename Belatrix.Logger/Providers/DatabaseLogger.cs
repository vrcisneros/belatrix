using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Belatrix.Logger
{
    public class DatabaseLogger : ILogger
    {
        public void LogMessage(string message, MessageType type)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BelatrixDb"].ConnectionString))
            {
                string cmdText = "Insert into Log Values(@Message, @Type)";

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@Message", message);
                    command.Parameters.AddWithValue("@Type", type);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
