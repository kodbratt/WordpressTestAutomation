using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordpressAutomation;

namespace WordpressTests
{
    [TestClass]
    public class CreatePostTests : WordpressTest
    {
      
        [TestMethod]
        public void Can_Create_A_Basic_Post()
        {
            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the test post").WithBody("Hi this is the body").Publish();

            NewPostPage.GoToNewPost();

            Assert.AreEqual(PostPage.Title, "This is the new post title", "Title did not match new post");
        }

    
    }
}
