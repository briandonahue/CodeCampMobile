
using System;
using SQLite;
using System.IO;
using CodeCampSchedule.Core.Data;

namespace CodeCampSchedule.Core
{


	public class DatabaseFactory
	{

		public DatabaseFactory ()
		{
		}
		
		public SQLiteConnection InitDb(){
			var pathToDb = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "sessions.db");
			if(!File.Exists(pathToDb))
			{
				File.Copy("sessions.db", pathToDb);
			}
			
			var conn = new SQLiteConnection(pathToDb);

			conn.CreateTable<TimeSlot>();
			conn.CreateTable<Session>();
			conn.CreateTable<LastUpdate>();
			return conn;

		}
	}
}
