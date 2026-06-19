using System;

namespace internat_bd.Models
{
    public class NewsItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public DateTime PublishedAt { get; set; }
    }
}
