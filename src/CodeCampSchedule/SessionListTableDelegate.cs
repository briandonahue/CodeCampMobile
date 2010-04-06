
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Linq;

namespace CodeCampSchedule
{


	public class SessionListTableDelegate: UITableViewDelegate
	{

		private SessionListController sessionListController;

		public SessionListTableDelegate (SessionListController controller)
		{
			sessionListController = controller;
		}


	}
}
