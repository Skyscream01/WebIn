using System;
using System.Diagnostics;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using ProductX.framework.Steps;

namespace ProductX.Framework
{
    [TestFixture]
    public class BaseTest : BaseEntity
    {
        private String _baseUrl;
        public UserSteps User;

        [SetUp]
        public void SetUp()
        {
            User = new UserSteps();
            _baseUrl = "https://y.prelive.webinfinity.com/";
            Browser.GetInstance();
            Browser.GetDriver().Manage().Window.Maximize();
            Browser.GetDriver().Navigate().GoToUrl(_baseUrl);
        }

// Commented code should kill all Chrome instances. Should be used on Jenkins nodes.
        [TearDown]
        public void TearDown()
        {
            //var processes = Process.GetProcessesByName(RunConfigurator.GetValue("browser"));
            //foreach (var process in processes)
            //{
            //    process.Kill();
            //}
            Browser.GetDriver().Quit();
        }
    }
}
