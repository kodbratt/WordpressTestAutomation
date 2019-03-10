using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordpressAutomation.Navigation;

namespace WordpressAutomation
{
    public class LeftNavigation
    {
        public class Posts
        {
            public class AddNew
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-post", "Add New");
          
                }
            }
            public class AllPosts
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-post", "All Posts");
                }
            }
        }

        public class Pages
        {
            public class AllPages
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-pages", "All Pages");
                }
            }
        }
    }

  
}
