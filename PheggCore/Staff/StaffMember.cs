using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PheggCore.Staff
{
	public class StaffMember
	{
		public StaffMember(string UserId)
		{
			UserID = UserId;

			using (MySqlConnection conn = new MySqlConnection(StaticCore.PlayerStatsConnectionString))
			{
				conn.Open();
				DataTable dt = new DataTable();

				MySqlCommand cmd = new MySqlCommand("SELECT * FROM StaffData WHERE DiscordId = @id", conn);
				cmd.Parameters.AddWithValue("@id", UserId);

				cmd.Prepare();
				using (MySqlDataReader reader = cmd.ExecuteReader())
				{
					dt.Load(reader);

					if (dt.Rows.Count > 0)
					{
						Department = dt.Rows[0]["Rank"].ToString();
						IsManagement = bool.TryParse(dt.Rows[0].ToString(), out bool isMgm) && isMgm;
						Mentor = dt.Rows[0]["Mentor"].ToString();
						Name = dt.Rows[0]["Name"].ToString();
					}

					else
					{
						IsStaff = false;
						return;
					}
				}

				cmd = new MySqlCommand("SELECT * FROM AdminPerms WHERE UserId = @Id", conn);
				cmd.Parameters.AddWithValue("@Id", UserId);

				cmd.Prepare();
				using (MySqlDataReader reader = cmd.ExecuteReader())
				{
					dt.Load(reader);

					if (dt.Rows.Count > 1 && int.TryParse(dt.Rows[0]["Permissions"].ToString(), out int permInt))
					{
						WebsitePermissions = (WebsitePermissions)permInt;
						ApiKey = dt.Rows[0]["APIKey"].ToString();
					}
				}
			}

			IsStaff = true;	
		}

		public StaffMember(string Name, string UserId)
		{
			this.Name = Name;
			UserID = UserID;
		}

		public bool IsStaff { get; }

		public string Name { get; }
		public string UserID { get; }
		public WebsitePermissions WebsitePermissions { get; } = WebsitePermissions.None;
		public string Department { get; }
		public bool IsManagement { get; }
		public string Mentor { get; }
		public string ApiKey { get; }

		public bool HasPerm(WebsitePermissions Perm)
		{
			return WebsitePermissions.HasFlag(Perm);
		}
	}
}
