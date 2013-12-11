// -----------------------------------------------------------------------
//  <copyright file="RavenController.cs" company="Hibernating Rhinos LTD">
//      Copyright (c) Hibernating Rhinos LTD. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

using System.Web.Mvc;
using System.Xml.Linq;
using Raven.Client;

namespace Raven.Workshop.Web.Controllers
{
	public abstract class RavenController : Controller
	{
		public static IDocumentStore DocumentStore
		{
			get { return DocumentStoreHolder.Store; }
		}

		public IDocumentSession RavenSession { get; protected set; }

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			RavenSession = DocumentStoreHolder.Store.OpenSession();
		}

		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			if (filterContext.IsChildAction)
				return;

			using (RavenSession)
			{
				if (filterContext.Exception != null)
					return;

				if (RavenSession != null)
					RavenSession.SaveChanges();
			}
		}
	}
}