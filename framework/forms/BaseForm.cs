using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProductX.framework;
using ProductX.Framework.Elements;

namespace ProductX.Framework.Forms
{
    public class BaseForm : BaseEntity
    {
        private readonly String _name;
        private readonly By _locator;

        protected BaseForm(By locator, String name)
        {
            _locator = locator;
            _name = name;
            AssertIsPresent();
        }
        private readonly string COUNTER_AMOUNT = "//*[contains(text(), '{0}')]/parent::*/parent::*/div[contains(@class, 'count-content')]/span";
        protected readonly Button btnAddContent = new Button(By.XPath("//a[contains(@data-test-id, 'AddContentStart')]"), "Add content button");
        private readonly Button btnSearch = new Button(By.XPath("//p[contains(@ng-show, 'filterState.topBarSearchTerm')]/xd-literal[contains(@ref, 'SEARCHBOX-SEARCH-CONTENT')]"), "Search label");
        private readonly TextBox tbSearch = new TextBox(By.Id("explore-inpt"), "Search textbox");
        private CreateContentPane createContentPane;

        public CreateContentPane AtCreateContentPane()
        {
            if (createContentPane == null)
            {
                createContentPane = new CreateContentPane();
            }
            return createContentPane;
        }

        private void AssertIsPresent()
        {
            BaseElement.WaitForElementPresent(_locator, "Form " + _name);
            Log.Info(String.Format("Form '{0}' has appeared", _name));
        }

// Find if specified text is present on form
        public void CheckTextOnForm(String text)
        {
            BaseElement.WaitForElementPresent(By.XPath("//*[contains(.,'" + text + "')]"), text);
            Log.Info(String.Format("Text '{0}' is shown on the page", text));
        }

        private void ElementIsPresent(By element, string name)
        {
            BaseElement.WaitForElementPresent(element, "Form " + name);
            Log.Info(String.Format("Form '{0}' has appeared", name));
        }

        protected string GetCount(string name)
        {
            Button btnCounter = new Button(By.XPath(string.Format(COUNTER_AMOUNT, name)), "Counter " + name + " widget");
            return btnCounter.GetText();
            //return Browser.GetDriver().FindElement(By.XPath(string.Format(COUNTER_AMOUNT, name))).Text;
        }

        public void ClickAddContent()
        {
            btnAddContent.Click();
        }

        public void PerformSearch(string search)
        {
            btnSearch.WaitForElementIsClickable();
            btnSearch.Click();
            tbSearch.WaitForElementIsClickable();
            tbSearch.ClearSetText(search);
            tbSearch.PressEnter();
        }
        public void SwitchToMain()
        {
            Browser.GetDriver().SwitchTo().Window(Store.MainHandle);
        }
        //---------------------------------------------------------------------Sub-pages---------------------------------------------------------------

        public class CreateContentPane
        {
            public void SelectPublishType(string type)
            {
                Button btnPublishType = new Button(By.XPath(string.Format(
                    "//div[contains(@class, 'ui-x-menu-addContent')]//*[contains(text(), '{0}')]", type)), type + " type button");
                btnPublishType.Click();
            }
        }

    }
}
