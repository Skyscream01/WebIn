using System;
using OpenQA.Selenium;

namespace ProductX.Framework.Elements
{
    public class Link : BaseElement
    {
        public Link(By locator, String name) : base(locator, name) { }
    }
}
