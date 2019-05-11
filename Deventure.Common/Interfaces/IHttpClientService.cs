using System.Net.Http;

namespace Deventure.Common.Interfaces
{
	public interface IHttpClientService
	{
	    HttpClient GetNativeHttpClientInstance();
	}
}