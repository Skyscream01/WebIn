using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace ProductX.Framework.Elements
{
    public abstract class BaseElement : BaseEntity
    {
        private readonly RemoteWebElement _element;
        private readonly String _name;
        private readonly By _locator;

        protected BaseElement(By locator, String name)
        {
            this._name = name;
            this._locator = locator;
        }

//USE WISELY! Getting text of element. ToDo need to add catch expection if there is no text.
        public string GetText()
        {
            WaitForElementPresent();
            return Browser.GetDriver().FindElement(_locator).Text;
        }

        protected RemoteWebElement GetElement()
        {
            WaitForElementPresent();
            return (RemoteWebElement) Browser.GetDriver().FindElement(_locator);
        }

        protected String GetName()
        {
            return _name;
        }

        protected By GetLocator()
        {
            return _locator;
        }

// Just clicks target element.
        public void Click()
        {
            WaitForElementPresent();
            WaitForElementIsVisible();
            GetElement().Click();
            Log.Info(String.Format("{0} :: click", GetName()));
        }

// Gets any attribute value. Specify attribute name in value string.
        public string GetAttribyteValue(string value)
        {
            return GetElement().GetAttribute(value);
        }

        // Assert the target element is present
        public Boolean IsPresent()
        {
            return Browser.GetDriver().FindElements(_locator).Count > 0;
        }

// Sinple wait of target element is present.
        public void WaitForElementPresent()
        {
            var wait = new WebDriverWait(Browser.GetDriver(),
                TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until(waiting =>
                {
                    var webElements = Browser.GetDriver().FindElements(_locator);
                    return webElements.Count != 0;
                });
            }
            catch (TimeoutException)
            {
                Log.Fatal(string.Format("Element with locator: '{0}' does not exists!", _locator));
            }
        }

// Waits utnil specified (locator) element is present. String name for logs
        public static void WaitForElementPresent(By locator, String name)
        {
            var wait = new WebDriverWait(Browser.GetDriver(),
                TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until(waiting =>
                {
                    try
                    {
                        var webElements = Browser.GetDriver().FindElements(locator);
                        return webElements.Count != 0;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                });
            }
            catch (TimeoutException)
            {
                Log.Fatal(string.Format("Element with locator: '{0}' does not exists!", locator));
            }
        }

        public void WaitForElementIsVisible()
        {
            var wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_locator));
        }

        public void WaitForElementIsClickable()
        {
            var wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(_locator));
        }

        public void WaitForElementDisappear()
        {
            var wait = new WebDriverWait(Browser.GetDriver(),
                TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until(waiting =>
                {
                    var webElements = Browser.GetDriver().FindElements(_locator);
                    return webElements.Count == 0;
                });
            }
            catch (TimeoutException)
            {
                Log.Fatal(string.Format("Element with locator: '{0}' still exists!", _locator));
            }
        }
    }
}
