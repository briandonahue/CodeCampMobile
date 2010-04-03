
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using CodeCampSchedule.Core;

namespace CodeCampSchedule
{

public class HomeController : UITableViewController
{
    public override void ViewDidLoad ()
    {
		TableView.DataSource = new SessionTimeDataSource(new DatabaseFactory().InitDb());
	    	TableView.Delegate = new HomeTableDelegate(this);
	    	Title = "Philly.NET Code Camp";

    	base.ViewDidLoad ();
    }
}


}
