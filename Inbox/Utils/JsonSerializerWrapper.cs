using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Inbox.Utils
{
    public static class JsonSerializerWrapper
    {
        public static T Deserialize<T>(string content)
        {
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true, 
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals
            };
            
            return JsonSerializer.Deserialize<T>(content, options);
        }
    }

}