
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CodeCampSchedule
{
	public partial class SessionDetails : UIViewController
	{
		#region Constructors

		// The IntPtr and initWithCoder constructors are required for controllers that need 
		// to be able to be created from a xib rather than from managed code

		public SessionDetails (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public SessionDetails (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public SessionDetails () : base("SessionDetails", null)
		{
			Initialize ();
		}

		void Initialize ()
		{
		}
		
		#endregion
		
		public override void ViewDidLoad ()
		{
		//	sessionTitle.Text = "A  Very Very Very Very Very Very Very Very Very Long Title"; 
			base.ViewDidLoad ();
		}

		
		
	}
}
