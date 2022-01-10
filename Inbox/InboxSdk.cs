using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Inbox.Clients;
using Inbox.Models.Response;

namespace Inbox
{
    public class InboxSdk
    {
        private readonly InboxClient _client;
        private readonly HttpClient _httpClient;
        private readonly string _token;
        
        public InboxSdk(string email, string password)
        {
            _httpClient = new HttpClient();
            _client = new InboxClient(_httpClient);
            _token = GetToken(email, password).Result.Token.AccessToken;
        }

        private async Task<TokenResponse> GetToken(string email, string password, CancellationToken cancellationToken = default)
        {
            var token = await _client.GetToken(email, password, cancellationToken);
            return token;
        }

        public async Task<List<ContactItem>> GetContactList(CancellationToken cancellationToken = default)
        {
            var contactList = await _client.GetContactList(_token, cancellationToken);   
            return contactList.Contact.ContactItems;
        }

        public async Task<List<NewsletterItem>> GetNewLetters(CancellationToken cancellationToken = default)
        {
            var newsletters = await _client.GetNewsletters(_token, cancellationToken);
            return newsletters.NewsletterResult.Items;
        }
    }
}