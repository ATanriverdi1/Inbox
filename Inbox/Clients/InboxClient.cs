using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Inbox.Models.Response;
using static Inbox.Utils.JsonSerializerWrapper;

namespace Inbox.Clients
{
    public class InboxClient
    {
        private readonly HttpClient _client;
        public InboxClient(HttpClient client)
        {
            _client = client;
        }
        
        public async Task<TokenResponse> GetToken(string email, string password, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://useapi.useinbox.com/token/");
            request.Content = JsonContent.Create(new {EmailAddress = email, Password = password});

            var response = await _client.SendAsync(request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            if (response.IsSuccessStatusCode) return Deserialize<TokenResponse>(content);
            response.EnsureSuccessStatusCode();
            return null;
        }

        public async Task<NewsletterResponse> GetNewsletters(string token, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://useapi.useinbox.com/inbox/v1/newsletters");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            var response = await _client.SendAsync(request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            if (response.IsSuccessStatusCode) return Deserialize<NewsletterResponse>(content);
            response.EnsureSuccessStatusCode();
            return null;
        }

        public async Task<ContactResponse> GetContactList(string token, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://useapi.useinbox.com/inbox/v1/contacts");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            var response = await _client.SendAsync(request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            if (response.IsSuccessStatusCode) return Deserialize<ContactResponse>(content);
            response.EnsureSuccessStatusCode();
            return null;
        }
    }
}