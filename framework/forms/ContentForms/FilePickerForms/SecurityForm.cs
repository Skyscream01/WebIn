using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProductX.Framework.Elements;
using ProductX.Framework.Forms;

namespace ProductX.framework.forms.ContentForms.FilePickerForms
{
    public class SecurityForm : BaseForm
    {
        private static readonly By TitleLocator = By.XPath("//div[text()='Have offline access']");
        public SecurityForm() : base(TitleLocator, "Security Form")
        {
        }
        private readonly Button btnAllow = new Button(By.XPath("//button[contains(@id, 'submit_approve_access')][not(@disabled='')]"), "Allow button");

        public void ClickAllow()
        {
            btnAllow.Click();
        }
    }
}
