using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProductX.Framework.Elements;
using ProductX.Framework.Forms;

namespace ProductX.framework.forms.ContentForms
{
    public class GoogleAuth : BaseForm
    {
        private static By TitleLocator = By.XPath("//div[contains(@class, 'logo')][contains(@aria-label, 'Google')]");

        public GoogleAuth() : base(TitleLocator, "Google Auth Form")
        {
        }
        private readonly TextBox tbEmail = new TextBox(By.Id("Email"), "Email textbox");
        private readonly Button btnNext = new Button(By.Id("next"), "Next button");
        private readonly TextBox tbPassword = new TextBox(By.Id("Passwd"), "Password textbox");
        private readonly Button btnSignIn = new Button(By.Id("signIn"), "signIn button");

        public void SetLogin(String login)
        {
            tbEmail.ClearSetText(login);
        }

        public void ClickNext()
        {
            btnNext.Click();
        }

        public void SetPassword(String password)
        {
            tbPassword.ClearSetText(password);
        }

        public void ClickSignIn()
        {
            btnSignIn.Click();
        }
    }
}
