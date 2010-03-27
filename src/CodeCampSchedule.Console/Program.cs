using System;
using System.Collections.Generic;
using CodeCampSchedule.Core;

namespace CodeCampSchedule
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileDownloader = new AsyncFileDownloader();
            var dataExtractor = new DataExtractor();

//            var waiter = new AutoResetEvent(false);
//            fileDownloader.OnDownloadCompleted += (sender, e) => waiter.Set();
//            fileDownloader.DownloadFileAtUrl(
//                "http://codecamp.phillydotnet.org/2010-1/_layouts/listfeed.aspx?List={447CD038-3CF6-484F-9C0B-A1AE5D979519}",
//                "sessionList.xml");
//            waiter.WaitOne();

            IEnumerable<SessionDTO> sessionDtos = dataExtractor.GetSessionData("sessionList.xml");


            int i = 0;
            foreach (SessionDTO session in sessionDtos)
            {
                Console.WriteLine("{0}. {1} ({2}): {3}, {4}, {5}, {6} \nBIO:{7}\nPHOTO: {8}",
                                  ++i, session.SpeakerName, session.Designation, session.Title, session.Time,
                                  session.Track, session.Description, session.SpeakerBio, session.PhotoUrl);
            }

            Console.Read();
        }
    }
}