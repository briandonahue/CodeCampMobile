
using System;
using System.Collections.Generic;

namespace CodeCampSchedule
{


	public interface ISessionRepository
	{
		IEnumerable<string> GetSessionsForTime(string time);
	}
}
