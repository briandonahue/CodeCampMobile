
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CodeCampSchedule
{

public class HomeController : UITableViewController
{
    public override void ViewDidLoad ()
    {
	    	TableView.DataSource = new SessionTimeDataSource();
	    	TableView.Delegate = new HomeTableDelegate(this);
	    	Title = "Philly.NET Code Camp";

    	base.ViewDidLoad ();
    }
}


}
