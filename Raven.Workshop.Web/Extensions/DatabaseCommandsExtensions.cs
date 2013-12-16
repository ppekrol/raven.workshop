using System;
using Raven.Client.Connection;
using Raven.Client.Document;

namespace Raven.Workshop.Web.Extensions
{
	public static class DatabaseCommandsExtensions
	{
		 public static void Delete<T>(this IDatabaseCommands self, ValueType id, DocumentConvention convention)
		 {
			 var fullId = convention.FindFullDocumentKeyFromNonStringIdentifier(id, typeof(T), false);
			 self.Delete(fullId, null);
		 }
	}
}