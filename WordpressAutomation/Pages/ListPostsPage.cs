using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordpressAutomation
{
    public class ListPostsPage
    {
        private static int lastCount;

        public static int PreviousPostCount
        {
            get { return lastCount; }
        }

        public static object CurrentPostCount
        {
            get { return GetPostCount(); }
                }

        public static bool IsAt
        {
            get
            {
                var h2s = Driver.Instance.FindElements(By.TagName("h2"));
                if (h2s.Count > 0)
                    return h2s[0].Text == "Posts";
                return false;
            }
        }

        public static void GoTo(PageType pageType)
        {
            switch (pageType)
            {
                case PageType.Page:
                    LeftNavigation.Pages.AllPages.Select();
                    break;
                case PageType.Posts:
                    LeftNavigation.Posts.AllPosts.Select();
                    if (!IsAt)
                    {
                        //Error.Log("Did not navigate to all posts!");
                    }
                    break;

            }
        }

        public static void SelectPost(string title)
        {
            var postLink = Driver.Instance.FindElement(By.LinkText("Sample Page"));
            postLink.Click();
        }

        public static void StoreCount()
        {
            lastCount = GetPostCount();
        }

        private static int GetPostCount()
        {
            var countText = Driver.Instance.FindElement(By.ClassName("displaying-num")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static bool DoesPostExistWithTitle(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Any();
        }

        public static void Trash(string title)
        {
            var rows = Driver.Instance.FindElements(By.TagName("tr"));

            foreach (var row in rows)
            {
                ReadOnlyCollection<IWebElement> links = null;
                Driver.NoWait(() => links = row.FindElements(By.LinkText(title)));

                if (links.Count > 0 )
                {
                    Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(links[0]);
                    action.Perform();
                    row.FindElement(By.ClassName("submitdelete")).Click();
                    return;
                }
            }
        }

        public static bool DoesPostExistWithTitle(object previousTitle)
        {
            throw new NotImplementedException();
        }

        public static void SearchForPost(string searchString)
        {
            if (!IsAt)
            {
                GoTo(PageType.Posts);
            }

            var searchBox = Driver.Instance.FindElement(By.Id("post-search-input"));
            searchBox.SendKeys(searchString);

            var searchButton = Driver.Instance.FindElement(By.Id("search-submit"));
            searchButton.Click();
        }
    }

    public enum PageType
    {
        Page,
        Posts
    }
}
