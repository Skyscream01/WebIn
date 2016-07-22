using System;
using NUnit.Framework;
using OpenQA.Selenium;
using ProductX.Framework;
using ProductX.Framework.Elements;
using ProductX.Framework.Forms;

namespace ProductX.framework.forms
{

    public class MainForm : BaseForm
    {
        private static By TitleLocator = By.TagName("iframe");

        public MainForm() : base(TitleLocator, "Main Form")
        {
        }
        private readonly TextBox tbUserName = new TextBox(By.Id("username"), "Username");
        private readonly TextBox tbPassword = new TextBox(By.Id("password"), "Password");
        private readonly Button btnLogin = new Button(By.XPath("//input[contains(@value, 'Login')]"), "Login button");
        private readonly Label lblError = new Label(By.XPath("//p[contains(@ng-bind-html, 'errorMessage')]"), "Error label");

        public void CheckInvalidCreds()
        {
            lblError.WaitForElementPresent();
            Assert.AreEqual(lblError.GetText(), "Invalid email and password combination", "Label does not match");
            Log.Info("Label is correct");
        }

        public void SwitchToAuthFrame()
        {
            SwitchToIframe("iframe");
        }

        public void SetUserName(String username)
        {
            tbUserName.SetText(username);
        }

        public void SetPassword(String password)
        {
            tbPassword.SetText(password);
        }

        public void ClickLogin()
        {
            btnLogin.Click();
        }
        private void SwitchToIframe(String frame)
        {
            BaseElement.WaitForElementPresent(By.TagName(frame), frame);
            Browser.GetDriver().SwitchTo().Frame(Browser.GetDriver().FindElement(By.TagName(frame)));
        }
    }
}
