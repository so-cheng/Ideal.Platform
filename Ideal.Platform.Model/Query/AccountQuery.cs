using System;
namespace Ideal.Platform.Model.Query
{
	public class AccountQuery : QueryMust
    {
		public string UserName { get; set; }

		public string AccountStatus { get; set; }
	}
}

