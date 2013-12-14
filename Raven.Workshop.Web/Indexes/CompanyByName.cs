using System.Linq;
using Raven.Client.Indexes;
using Raven.Workshop.Web.Models;

namespace Raven.Workshop.Web.Indexes
{
	public class CompanyByName : AbstractIndexCreationTask<Company>
	{
		public CompanyByName()
		{
			Map = companies => from company in companies
			                   select new
				                   {
					                   company.Name
				                   };
		}
	}
}