
using System;
using System.Collections.Generic;

namespace CodeCampSchedule
{


	public class StubSessionRepo: ISessionRepository
	{
		public IEnumerable<string> GetSessionsForTime (string time)
		{
			return new List<string>{"Session 1", "Session 2", "Session 3" };
			
		}

	}
}
