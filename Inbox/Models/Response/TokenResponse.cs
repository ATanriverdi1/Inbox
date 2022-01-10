using System.Text.Json.Serialization;

namespace Inbox.Models.Response
{
    public class TokenResponse
    {
        [JsonPropertyName("resultObject")]
        public TokenResult Token { get; set; }
    }
    public class TokenResult
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }
}