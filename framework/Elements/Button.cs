using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ProductX.Framework.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator, String name) : base(locator, name)
        {
        }

//Mouse pointer hovers over the button
        public void Move()
        {
            Actions move = new Actions(Browser.GetDriver());
            move.MoveToElement(GetElement()).Build().Perform();
            Log.Info(string.Format("Mouse pointer hover over '{0}'", GetName()));
        }
    }
}
