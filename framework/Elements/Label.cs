using System;
using OpenQA.Selenium;

namespace ProductX.Framework.Elements
{
    public class Label : BaseElement
    {
        public Label(By locator, String name) : base(locator, name) { }
    }
}
