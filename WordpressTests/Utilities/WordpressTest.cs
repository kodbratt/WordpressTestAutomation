using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordpressAutomation;
using WordpressAutomation.Workflows;

namespace WordpressTests
{
    [TestClass]
    public class WordpressTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
            PostCreator.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs("user").WithPassword("pass").Login();
        }
        [TestCleanup]
        public void CleanUp()
        {
            PostCreator.CleanUp();
            Driver.Close();
        }
    }
}
