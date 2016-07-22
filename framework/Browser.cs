using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ProductX.Framework
{

    public class Browser : BaseEntity
    {
        protected static Browser _browser;
        private static IWebDriver _driver;
// Sets up WebDriver Instance.       
        public static Browser GetInstance()
        {
           _driver = BrowserFactory.SetupBrowser();
           
            return new Browser();
        }
// Gets current WebDriver Instance.
        public static IWebDriver GetDriver()
        {
            return _driver;
        }
// Waits for page is loaded. Never works fine :)
        public static void WaitForPageToLoad()
        {
            var wait = new WebDriverWait(GetDriver(), TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until<Boolean>(waiting =>
                {
                    try
                    {
                        var result = ((IJavaScriptExecutor)Browser.GetDriver()).ExecuteScript("return document['readyState'] ? 'complete' == document.readyState : true");
                        return result != null && result is Boolean && (Boolean)result;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });
            }
            catch (Exception e)
            {
            }
        }

    }
}
