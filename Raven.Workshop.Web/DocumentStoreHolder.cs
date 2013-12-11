namespace Raven.Workshop.Web
{
    using Raven.Client;

    public static class DocumentStoreHolder
    {
        public static IDocumentStore Store { get; set; }
    }
}