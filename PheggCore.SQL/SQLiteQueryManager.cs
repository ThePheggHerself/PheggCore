using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PheggCore.SQL
{
	public static class SQLiteQueryManager
	{
		public static DataTable ReadFromDatabase(this SqliteCommand Cmd, string File, Dictionary<string, string> Values = null)
		{
			try
			{
				DataTable dataTable = new DataTable();

				using (var conn = new SqliteConnection($"Data Source={File}"))
				{
					Cmd.Connection = conn;

					conn.Open();

                    if (Values != null)
                    {
                        foreach (var value in Values)
                        {
                            Cmd.Parameters.AddWithValue($"@{value.Key}", value.Value);
                        }
                    }

					Cmd.Prepare();

					using (SqliteDataReader reader = Cmd.ExecuteReader())
					{
						dataTable.Load(reader);
					}

					conn.Close();
				}

				return dataTable;
			}
			catch (Exception e)
			{
				Logger.Write(e.ToString(), Logger.MessageSeverity.Error);
				return null;
			}
		}

		public static void WriteToDatabase(this SqliteCommand Cmd, string File, Dictionary<string, string> Values = null)
		{
			try
			{
				using (var conn = new SqliteConnection($"Data Source={File}"))
				{
					Cmd.Connection = conn;

					conn.Open();

					foreach (var kvp in Values)
					{
						Cmd.Parameters.AddWithValue($"@{kvp.Key}", kvp.Value);
					}

					Cmd.Prepare();

					Cmd.ExecuteNonQuery();

					conn.Close();
				}
			}
			catch (Exception e)
			{
				Logger.Write(e.ToString(), Logger.MessageSeverity.Error);
			}
		}
	}
}
