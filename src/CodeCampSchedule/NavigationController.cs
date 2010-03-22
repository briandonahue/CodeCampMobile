
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CodeCampSchedule
{

public class NavigationController : UINavigationController
{
    HomeController homeController;

    public override void ViewDidLoad ()
    {
    	homeController = new HomeController();
    	PushViewController(homeController, true);
    	base.ViewDidLoad ();
    }
}
}
