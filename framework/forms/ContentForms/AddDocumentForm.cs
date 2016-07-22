using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProductX.Framework;
using ProductX.Framework.Elements;

namespace ProductX.framework.forms.ContentForms
{
    public class AddDocumentForm : AddContentForm
    {
        private readonly Label lblTitle = new Label(By.XPath("//input[contains(@readonly, 'readonly')]"), "Document title label");
        private readonly Label lblProccessing = new Label(By.XPath("//xd-literal[contains(text(), 'Processing')]"), "Proccessing label");
        private readonly Button btnRemove = new Button(By.XPath("//a[contains(@data-test-id, 'contentCreateStep1-removeEmbedInfo')]"), "Remove button");

        public void OpenFilepicker()
        {
         lblTitle.Click();  
        }

        public void SwitchToLastWindow()
        {
            //Browser.GetDriver().SwitchTo().Window(Browser.GetDriver().WindowHandles.ToList().Last());
            // Get the current window handle so you can switch back later.
            Store.MainHandle = Browser.GetDriver().CurrentWindowHandle;
            PopupWindowFinder finder = new PopupWindowFinder(Browser.GetDriver());
            lblTitle.WaitForElementPresent();
            lblTitle.WaitForElementIsVisible();
            string popupWindowHandle = finder.Click(Browser.GetDriver().FindElement(By.XPath("//input[contains(@readonly, 'readonly')]")));
            Browser.GetDriver().SwitchTo().Window(popupWindowHandle);
        }

        public void WaitTillFileUpload()
        {
            //Button check = new Button(By.XPath("//xd-literal[contains(text(), 'What type of Content do you want to add?')]"), "Check button");
            //check.Click();
            btnRemove.WaitForElementPresent();
            //lblProccessing.WaitForElementDisappear();
        }
    }
}
