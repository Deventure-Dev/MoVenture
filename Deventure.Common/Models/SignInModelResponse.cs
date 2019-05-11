using System;
using Newtonsoft.Json;

namespace Deventure.Common.Models
{
	public class SignInModelResponse
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public double ExpiresIn { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty(".issued")]
        public DateTime Issued { get; set; }

        [JsonProperty(".expires")]
		public DateTime ExpirationDate { get; set; }
    }
}
