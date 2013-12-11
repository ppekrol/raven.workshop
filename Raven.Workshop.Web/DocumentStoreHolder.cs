// -----------------------------------------------------------------------
//  <copyright file="DocumentStoreHolder.cs" company="Hibernating Rhinos LTD">
//      Copyright (c) Hibernating Rhinos LTD. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

using Raven.Client;

namespace Raven.Workshop.Web
{
	public static class DocumentStoreHolder
	{
		public static IDocumentStore Store { get; set; }
	}
}