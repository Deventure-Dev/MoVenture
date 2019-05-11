using System.Collections.Generic;

namespace Deventure.Common.Interfaces
{
	public interface IAuthenticationService
	{
		IDictionary<string, string> ComputeAuthenticationHeaders();
	}
}
