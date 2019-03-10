using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordpressAutomation.Workflows
{
    public class PostCreator
    {
        public static string PreviousTitle { get; set; }
        public static string PreviousBody { get; set; }
        public static bool CreatedAPost
        {
            get { return !string.IsNullOrEmpty(PreviousTitle); }
        }

        public static void CreatePost()
        {
            NewPostPage.GoTo();

            PreviousTitle = CreateTitle();
            PreviousBody = CreateBody();

            NewPostPage.CreatePost(PreviousTitle).WithBody(PreviousBody).Publish();
        }

        public static void Initialize()
        {
            PreviousTitle = null;
            PreviousBody = null;
        }

        public static void CleanUp()
        {
            if (CreatedAPost)
            {
                TrashPost();
            }
        }

        private static void TrashPost()
        {
            ListPostsPage.Trash(PreviousTitle);
            Initialize();
        }

        private static string CreateBody()
        {
            return CreateRandomString() + ", body";
        }

        private static string CreateRandomString()
        {
            var s = new StringBuilder();

            var random = new Random();

            var cycles = random.Next(5 + 1);

            for (int i = 0; i < cycles; i++)
            {
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
                s.Append(Articles[random.Next(Articles.Length)]);
                s.Append(" ");
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
            }
            return s.ToString();
        }

        private static string[] Words = new[]
        {
            "boy", "cat", "rabbit", "baseball", "throw", "find", "scary", "mustard"
        };

        private static string[] Articles = new[]
        {
            "the", "an", "and","a", "of", "to", "it", "as"
        };

        private static string CreateTitle()
        {
            return CreateRandomString() + "title";
        }
    }
}
