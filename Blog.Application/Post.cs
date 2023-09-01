using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application
{
    public class Post
    {
        public long Id { get; set; }
        public string Content { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Post(string content, string title)
        {
            Content = content;
            Title = title;
            CreatedAt = DateTime.Now;
        }

        public (bool, string) ValidateTitleLenght()
        {
            if (Title.Length < 5)
                return (false, "Content should have min 5 characteres");

            if (Title.Length > 50)
                return (false, "Content should have minimun max 50 characteres");

            return (true, "");
        }

        public (bool, string) ValidateContentLenght()
        {
            if (Content.Length < 5)
                return (false, "Content should have min 5 characteres");

            if (Content.Length > 500)
                return (false, "Content should have minimun max 500 characteres");

            return (true, "");
        }

    }
}
