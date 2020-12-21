using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_news.models
{
    public class Article
    {
        public Origin Source { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
