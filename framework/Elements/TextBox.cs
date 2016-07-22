using System;
using OpenQA.Selenium;

namespace ProductX.Framework.Elements
{
    public class TextBox : BaseElement
    {
        public TextBox(By locator, String name) : base(locator, name)
        {
        }

// Set string text in textbox.
        public void SetText(String text)
        {
            WaitForElementPresent();
            GetElement().Click();
            GetElement().SendKeys(text);
            Log.Info(String.Format("{0} :: type text '{1}'", GetName(), text));
        }

// Set string text in textbox clearing it before.
        public void ClearSetText(String text)
        {
            WaitForElementPresent();
            WaitForElementIsVisible();
            GetElement().Click();
            GetElement().Clear();
            GetElement().SendKeys(text);
            Log.Info(String.Format("{0} :: type text '{1}'", GetName(), text));
        }

        public void PressEnter()
        {
            WaitForElementPresent();
            WaitForElementIsVisible();
            GetElement().SendKeys(Keys.Enter);
            Log.Info(String.Format("{0} :: Press Enter'", GetName()));
        }
    }
}
