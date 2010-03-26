using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Xml.Linq;

namespace CodeCampSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            var waiter = new AutoResetEvent(false);
//            DownloadFileAsync(waiter);
 //           waiter.WaitOne();
            ExtractXML();
            Console.Read();
        }

        private static void DownloadFileAsync(AutoResetEvent waiter)
        {
            var webClient = new WebClient();
            var address = new Uri("http://codecamp.phillydotnet.org/2010-1/_layouts/listfeed.aspx?List={447CD038-3CF6-484F-9C0B-A1AE5D979519}", UriKind.Absolute);
            webClient.DownloadFileAsync(address, "sessionList.xml", waiter);
            webClient.DownloadFileCompleted += webClient_DownloadFileCompleted;
        }

        static void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {




           ((AutoResetEvent) e.UserState).Set();


        }

        private static void ExtractXML()
        {
            var sessionXml = XDocument.Load("sessionList.xml");
            var items = from item in sessionXml.Descendants("item")
                        select new {
                                       Title = item.Element("title").Value,
                                       Link = item.Element(("link")),
                                       Description = item.Element("description")
                                   };
            foreach (var item in items)
            {
                Console.WriteLine("{0}: {1}", item.Title, item.Description);
            }
        }
    }
}
