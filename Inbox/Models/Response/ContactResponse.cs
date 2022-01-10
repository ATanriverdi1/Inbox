using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Inbox.Models.Response
{
    public class ContactResponse
    {
        public ContactResponse()
        {
            Contact = new ContactResult();
        }
        
        [JsonPropertyName("resultObject")]
        public ContactResult Contact { get; set; }
    }

    public class ContactResult
    {
        public ContactResult()
        {
            ContactItems = new List<ContactItem>();
        }
        
        [JsonPropertyName("items")]
        public List<ContactItem> ContactItems { get; set; }
    }
    
    public class ContactItem : BaseResponse
    {
        public string? Email { get; set; }
    }
}