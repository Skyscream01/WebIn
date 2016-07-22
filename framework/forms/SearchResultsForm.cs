using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProductX.Framework.Elements;
using ProductX.Framework.Forms;

namespace ProductX.framework.forms
{
   public class SearchResultsForm : BaseForm
    {
        private static By TitleLocator = By.XPath("//li/*[contains(text(), 'Clear All')]");

        public SearchResultsForm() : base(TitleLocator, "Search results Form")
        {
        }

        public void OpenSearchItem(string name)
        {
            Button btnSearchItem = new Button(By.XPath(String.Format("//span[contains(text(), '{0}')]", name)), name+" search item");
            btnSearchItem.Click();
        }
    }
}
