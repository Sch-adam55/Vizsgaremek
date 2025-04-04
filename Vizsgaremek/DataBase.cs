using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace Vizsgaremek
{
	internal class Database
	{
		private string connectionString;
		public Database()
		{
			connectionString = "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;";
		}

		private MySqlConnection OpenConnection()
		{
			MySqlConnection conn = new MySqlConnection(connectionString);
			conn.Open();
			return conn;
		}

		public bool RegisterUser(string email, string profilename, string password)
		{
			string hashedPassword = HashPassword(password);

			using (var conn = OpenConnection())
			{
				string query = "INSERT INTO `user` (`email`, `profilename`, `password`) VALUES (@email, @profilename, @password)";
				MySqlCommand cmd = new MySqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@email", email);
				cmd.Parameters.AddWithValue("@profilename", profilename);
				cmd.Parameters.AddWithValue("@password", hashedPassword);

				try
				{
					cmd.ExecuteNonQuery();
					Console.WriteLine("User registered successfully.");
					return true;
				}
				catch (MySqlException ex)
				{
					Console.WriteLine("Error: " + ex.Message);
					return false;
				}
			}
		}

	
		public bool LoginUser(string email, string password)
		{
			using (var conn = OpenConnection())
			{
				string query = "SELECT `password` FROM `user` WHERE `email` = @email";
				MySqlCommand cmd = new MySqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@email", email);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();
						string storedHashedPassword = reader.GetString("password");

						if (VerifyPassword(password, storedHashedPassword))
						{
							Console.WriteLine("Login successful.");
							return true;
						}
						else
						{
							Console.WriteLine("Invalid password.");
							return false;
						}
					}
					else
					{
						Console.WriteLine("User not found.");
						return false;
					}
				}
			}
		}
		private string HashPassword(string password)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
				StringBuilder builder = new StringBuilder();
				foreach (byte b in bytes)
				{
					builder.Append(b.ToString("x2"));
				}
				return builder.ToString();
			}
		}
		private bool VerifyPassword(string password, string hashedPassword)
		{
			string hashedInputPassword = HashPassword(password);
			return hashedInputPassword == hashedPassword;
		}

	}
}
