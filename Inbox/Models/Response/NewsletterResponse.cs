using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Inbox.Models.Response
{
    public class NewsletterResponse
    {
        public NewsletterResponse()
        {
            NewsletterResult = new ();
        }

        [JsonPropertyName("resultObject")]
        public NewsletterResult NewsletterResult { get; set; }
    }

    public class NewsletterResult
    {
        public NewsletterResult()
        {
            Items = new ();
        }
        [JsonPropertyName("items")]
        public List<NewsletterItem> Items { get; set; }
    }
    
    public class NewsletterItem : BaseResponse
    {
        public string? Subject { get; set; }
        public string? HtmlContent { get; set; }
    }
}