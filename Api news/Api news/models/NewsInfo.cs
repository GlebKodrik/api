using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api_news.models
{
    public class NewsInfo
    {
        [JsonProperty("articles")]
        public List<Article> Articles { get; set; }
    }
}
