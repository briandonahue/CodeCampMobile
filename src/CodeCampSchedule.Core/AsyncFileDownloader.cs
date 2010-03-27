using System;
using System.ComponentModel;
using System.Net;

namespace CodeCampSchedule.Core
{
    public class AsyncFileDownloader
    {
        public event EventHandler<AsyncCompletedEventArgs> OnDownloadCompleted;

        public void DownloadFileAtUrl(string url, string targetFile)
        {
            var webClient = new WebClient();
            webClient.DownloadFileCompleted += (sender, e) => {if(OnDownloadCompleted != null) OnDownloadCompleted.Invoke(sender, e);};
            webClient.DownloadFileAsync(new Uri(url), targetFile); 
        }
    }
}