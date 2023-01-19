using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PheggCore.Staff
{
	public enum WebsitePermissions
	{
		None = 0,
		ViewApplications = 1 << 1,
		ViewAppeals = 1 << 2,
		ViewSurvey = 1 << 3,
		RequestSurvey = 1 << 4,
		DeletePunishments = 1 << 5,
		DeletePunishmentsOfOthers = 1 << 6,
		EditPunishments = 1 << 7,
		EditPunishmentsOfOthers = 1 << 8,
		UserNote = 1 << 9,
		ViewPunishments = 1 << 10,
	}
}
