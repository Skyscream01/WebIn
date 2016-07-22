using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace ProductX.Framework
{
    public class BrowserFactory : BaseEntity
    {
        private const String DriverPath = "../../resources/";

        /// <summary>
        /// setup webdriver. chromedriver is a default value
        /// </summary>
        /// <returns>driver</returns>
        public static IWebDriver SetupBrowser()
        {
            String env = RunConfigurator.GetValue("env");
            if (env == "remote")
            {
                DesiredCapabilities capability = new DesiredCapabilities();
                if (RunConfigurator.GetValue("bsplatform")=="desktop")
                {
                    if (RunConfigurator.GetValue("bsbrowser") == "Chrome")
                    {
                        capability = DesiredCapabilities.Chrome();
                        capability = ConfigureDesktopCapabilities(capability);
                    }
                    if (RunConfigurator.GetValue("bsbrowser") == "Firefox")
                    {
                        capability = DesiredCapabilities.Firefox();
                        capability = ConfigureDesktopCapabilities(capability);
                    }
                    if (RunConfigurator.GetValue("bsbrowser") == "IE")
                    {
                        capability = DesiredCapabilities.InternetExplorer();
                        capability = ConfigureDesktopCapabilities(capability);
                    }
                    if (RunConfigurator.GetValue("bsbrowser") == "Safari")
                    {
                        capability = DesiredCapabilities.Safari();
                        capability = ConfigureDesktopCapabilities(capability);
                    }
                }
                if (RunConfigurator.GetValue("bsplatform") == "device")
                {
                    if (RunConfigurator.GetValue("bsbrowsername") == "android")
                    {
                        capability = DesiredCapabilities.Android();
                        capability = ConfigureDeviceCapabilities(capability);
                    }
                    if (RunConfigurator.GetValue("bsbrowsername") == "iPhone")
                    {
                        capability = DesiredCapabilities.IPhone();
                        capability = ConfigureDeviceCapabilities(capability);
                    }
                }
                return new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
            }
            if (env == "local")
            {
                ChromeOptions options = new ChromeOptions();
                options.AddUserProfilePreference("safebrowsing.enabled", true);
                return new ChromeDriver(System.IO.Path.GetFullPath(DriverPath), options);
            }
            return new ChromeDriver(System.IO.Path.GetFullPath(DriverPath));
        }

        private static DesiredCapabilities ConfigureDesktopCapabilities(DesiredCapabilities capability)
        {
            capability.SetCapability("browserstack.user", RunConfigurator.GetValue("bsuser"));
            capability.SetCapability("browserstack.key", RunConfigurator.GetValue("bskey"));
            capability.SetCapability("browser", RunConfigurator.GetValue("bsbrowser"));
            capability.SetCapability("browser_version", RunConfigurator.GetValue("bsbrowserversion"));
            capability.SetCapability("os", RunConfigurator.GetValue("bsos"));
            capability.SetCapability("os_version", RunConfigurator.GetValue("bsosversion"));
            capability.SetCapability("resolution", RunConfigurator.GetValue("bsresolution"));
            return capability;
        }
        private static DesiredCapabilities ConfigureDeviceCapabilities(DesiredCapabilities capability)
        {
            capability.SetCapability("browserstack.user", RunConfigurator.GetValue("bsuser"));
            capability.SetCapability("browserstack.key", RunConfigurator.GetValue("bskey"));
            capability.SetCapability("browserName", RunConfigurator.GetValue("bsbrowsername"));
            capability.SetCapability("platform", RunConfigurator.GetValue("bsosplatform"));
            capability.SetCapability("device", RunConfigurator.GetValue("bsdevice"));
            return capability;
        }
    }
}
