
using System;
using System.Collections.Generic;
using CodeCampSchedule.Core.Data;
using System.Linq;
using SQLite;
using System.IO;

namespace CodeCampSchedule.Core
{


	public class Database
	{
		
		SQLiteConnection conn = null;
		public Database(){
			var pathToDb = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "sessions.db");
			if(!File.Exists(pathToDb))
			{
				File.Copy("sessions.db", pathToDb);
			}
			
			conn = new SQLiteConnection(pathToDb);

			conn.CreateTable<TimeSlot>();
			conn.CreateTable<Session>();
			conn.CreateTable<LastUpdate>();
		}


		public void UpdateData (IEnumerable<Session> sessions)
		{
			conn.Execute("DROP TABLE session");
//			conn.Execute("UPDATE sqlite_sequence SET seq = 0 WHERE name = 'Session'");
			conn.CreateTable<Session>();
			conn.InsertAll<Session>(sessions);
			conn.Execute("DELETE FROM LastUpdate");
			conn.Insert(new LastUpdate(DateTime.Now));
		}
		


		public IEnumerable<TimeSlot> GetAvailableTimeSlots ()
		{
			return from t in conn.Table<TimeSlot>() orderby t.Time select t;
			
		}
	}
}
