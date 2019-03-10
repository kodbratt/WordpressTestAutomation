using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordpressAutomation;
using WordpressAutomation.Workflows;

namespace WordpressTests.PostsTests
{
    public class AllPostsTests : WordpressTest
    {
        //Added posts show up in all posts
        //Can activate excerpt mode
        //Can add new post
        
        //Single post selection

        //Can select a post by title
        //Can select a post by edit
        //Can select a post by quickedit
        //Can trash a post
        //Can view a post
        //Can filter by autor
        //Can filter by category
        //Can filter by tag
        //Can go to post comments

        //Bulk actions

        //Can edit multiple posts
        //Can trash multiple posts
        //Can select all posts

        //Drop down filters

        //Can filter by month
        //Can filter by category
        //Can view published only
        //Can view drafts only
        //Can view trash only

        //Can search posts

        //Added posts show up in all posts
        //Can trash a post
        //Can search posts

        [TestMethod]
        public void Added_Posts_Show_Up_And_Gets_Trashed()
        {
            //Go to posts, get post count, store
            ListPostsPage.GoTo(PageType.Posts);
            ListPostsPage.StoreCount();

            //Add new post
            PostCreator.CreatePost();
    


            //Go to post, get new post count
            ListPostsPage.GoTo(PageType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount, "Count of post did not increase");

            //Check for added post
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            //Trash post (clean up)
            ListPostsPage.Trash(PostCreator.PreviousTitle);
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Couldnt trash post");
        }

        [TestMethod]
        public void Can_Search_Posts()
        {
            //Create a new post
            PostCreator.CreatePost();

            //Search for post
            ListPostsPage.SearchForPost(PostCreator.PreviousTitle);

            //Check that post shows up in results
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));
        }
    }
}
