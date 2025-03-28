using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Vizsgaremek
{
	internal class Database
	{
		private string connectionString = "server=localhost;database=;user=root;";

		public bool AuthenticateUser(string username, string password)
		{
			using (MySqlConnection conn = new MySqlConnection(connectionString))
			{
				try
				{
					conn.Open();
					string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = SHA2(@password, 256)";
					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@username", username);
						cmd.Parameters.AddWithValue("@password", password);

						int count = Convert.ToInt32(cmd.ExecuteScalar());
						return count > 0;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Adatbázis hiba: " + ex.Message);
					return false;
				}
			}
		}
	}
}
