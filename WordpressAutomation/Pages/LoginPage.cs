using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace WordpressAutomation
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "wp-login.php");

            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "user_login");

        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
        }
    }



    public class LoginCommand
    {
        private readonly string username;
        private  string password;

        public LoginCommand(string userName)
        {
            this.username = userName;
        }

        public void Login()
        {
            var loginInput = Driver.Instance.FindElement(By.Id("user_login"));
            loginInput.SendKeys(username);

            var passwordInput = Driver.Instance.FindElement(By.Id("user_pass"));
            passwordInput.SendKeys(password);

            var loginButton = Driver.Instance.FindElement(By.Id("wp-submitt"));
            loginButton.Click();
        }

        public LoginCommand WithPassword(string passWord)
        {
            this.password = passWord;
            return this;
        }
    }
}
