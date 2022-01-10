using System;
using System.Text.Json.Serialization;

namespace Inbox.Models.Response
{
    public class BaseResponse
    {
        public string? Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}