namespace Raven.Workshop.Web.Controllers
{
    using System.Web.Mvc;

    using Raven.Client;

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