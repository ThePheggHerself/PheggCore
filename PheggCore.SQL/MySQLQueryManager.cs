using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PheggCore.SQL
{
	public static class MySQLQueryManager
	{
		public static DataTable ReadFromDatabase(this MySqlCommand Cmd, string ConString, Dictionary<string, string> Values = null)
		{
			try
			{
				if (Values != null)
				{
					foreach (var kvp in Values)
					{
						Cmd.Parameters.AddWithValue($"@{kvp.Key}", kvp.Value);
					}
				}

				DataTable dataTable = new DataTable();

				using (MySqlConnection conn = new MySqlConnection(ConString))
				{
					conn.Open();

					Cmd.Connection = conn;
					Cmd.Prepare();

					using (MySqlDataReader reader = Cmd.ExecuteReader())
					{
						dataTable.Load(reader);
					}

					Cmd.Dispose();
					conn.Close();
					conn.Dispose();
				}

				return dataTable;
			}
			catch (Exception e)
			{
				Logger.Write(e.ToString(), Logger.MessageSeverity.Error);
				return null;
			}
		}

		public static void WriteToDatabase(this MySqlCommand Cmd, string ConString, Dictionary<string, string> Values = null)
		{
			try
			{
                if (Values != null)
                {
                    foreach (var value in Values)
                    {
                        Cmd.Parameters.AddWithValue($"@{value.Key}", value.Value);
                    }
                }

                DataTable dataTable = new DataTable();

				using (MySqlConnection conn = new MySqlConnection(ConString))
				{
					conn.Open();

					Cmd.Connection = conn;
					Cmd.Prepare();
					Cmd.ExecuteNonQuery();

					Cmd.Dispose();
					conn.Close();
					conn.Dispose();
				}
			}
			catch (Exception e)
			{
				Logger.Write(e.ToString(), Logger.MessageSeverity.Error);
			}
		}
	}
}
