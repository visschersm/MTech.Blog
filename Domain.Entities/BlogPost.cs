using System.Collections.Generic;

namespace Domain.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;


        public Author Author { get; set; } = null!;

        public IList<Comment> Posts { get; set; } = new List<Comment>();
        public IList<Tag> Tags { get; set; } = new List<Tag>();
    }
}
