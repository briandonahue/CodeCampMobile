using System;
using System.ComponentModel;
using System.Net;

namespace CodeCampSchedule.Core
{
    public class AsyncFileDownloader
    {
        public event EventHandler<DownloadDataCompletedEventArgs> OnDownloadCompleted;
        public event EventHandler<ProgressChangedEventArgs> OnProgressChanged;

        public void DownloadDataAtUrl(string url)
        {
            var webClient = new WebClient();
            webClient.DownloadDataCompleted += (sender, e) => {if(OnDownloadCompleted != null) OnDownloadCompleted.Invoke(sender, e);};
            webClient.DownloadProgressChanged += (sender, e) => {if(OnProgressChanged != null) OnProgressChanged.Invoke(sender, e);};
            webClient.DownloadDataAsync(new Uri(url)); 
        }
    }
}