using OpenQA.Selenium;
using System;
using System.Threading;


namespace WordpressAutomation
{
    public class NewPostPage
    {
        public static object Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.Id("title"));
                if (title != null)
                    return title.GetAttribute("value");
                return string.Empty;
            }
                }

        public static void GoTo()
        {
            LeftNavigation.Posts.AddNew.Select();
     
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            var message = Driver.Instance.FindElement(By.Id("message"));
            var newPostlink = message.FindElements(By.TagName("a"))[0];

            newPostlink.Click();
        }

        public static bool IsInEditMode()
        {
            return Driver.Instance.FindElement(By.Id("icon-edit-pages")) != null;
        }
    }



    public class CreatePostCommand
    {
        private readonly string title;

        public void Publish()
        {
            Driver.Instance.FindElement(By.Id("title")).SendKeys(title);

            Driver.Instance.SwitchTo().Frame("content_ifr");
            Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
            Driver.Instance.SwitchTo().DefaultContent();

            Driver.Wait(TimeSpan.FromSeconds(1));
           

            Driver.Instance.FindElement(By.Id("publish")).Click();
        }

        private string body;

        public CreatePostCommand(string title)
        {
            this.title = title;
        }

        public CreatePostCommand WithBody(string body)
        {
            this.body = body;
            return this;
        }
    }
}
