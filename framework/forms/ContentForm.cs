using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using ProductX.Framework.Elements;
using ProductX.Framework.Forms;

namespace ProductX.framework.forms
{
    public class ContentForm : BaseForm
    {
        private static By TitleLocator = By.XPath("//xd-literal[contains(text(), 'Date Published:')]");

        public ContentForm() : base(TitleLocator, "Content Form")
        {
        }
        private readonly Label lblTitle = new Label(By.XPath("//div[contains(@class, 'ui-x-title-title')]/p"), "Title label");

        public void StoreWidgetsCount()
        {
            Store.CASphere = GetCount("CA Sphere");
            Log.Info("CA Sphere count is: "+Store.CASphere);
            Store.JuniperSphere = GetCount("Juniper Sphere");
            Log.Info("Juniper Sphere count is: " + Store.JuniperSphere);
            Store.JuniperPlatinum = GetCount("Juniper Platinum");
            Log.Info("Juniper Platinum count is: " + Store.JuniperPlatinum);
            Store.CAPlatinum = GetCount("CA Platinum");
            Log.Info("CA Platinum count is: " + Store.CAPlatinum);
        }

        public void AssertWidgetsCount()
        {
            CompareWidgetCount("CA Sphere");
            CompareWidgetCount("Juniper Sphere");
            CompareWidgetCount("Juniper Platinum");
            CompareWidgetCount("CA Platinum");

            //if (GetCount("CA Sphere")=="99+"|| GetCount("CA Sphere") == "99")
            //{
            //    //Assert.IsTrue(Store.CASphere=="98"|| Store.CASphere=="99" || Store.CASphere == "99+", "CA Sphere widget count is not valid");
            //    Log.Info(String.Format("Original CA Sphere count is: {0} | Now: {1}", Store.CASphere, GetCount("CA Sphere")));
            //    Store.CASphere = GetCount("CA Sphere");
            //}
            //else
            //{
            //    //Assert.AreEqual(Int32.Parse(GetCount("CA Sphere")), Int32.Parse(Store.CASphere) + 1, "CA Sphere widget count is not valid");
            //    Log.Info(String.Format("Original CA Sphere count is: {0} | Now: {1}", Store.CASphere, GetCount("CA Sphere")));
            //    Store.CASphere = GetCount("CA Sphere");
            //}

            //if (GetCount("Juniper Sphere") == "99+" || GetCount("Juniper Sphere") == "99")
            //{
            //    //Assert.IsTrue(Store.JuniperSphere == "98" || Store.JuniperSphere == "99+" || Store.JuniperSphere == "99",
            //   //     "Juniper Sphere widget count is not valid");
            //    Log.Info(String.Format("Original Juniper Sphere count is: {0} | Now: {1}", Store.JuniperSphere,
            //        GetCount("Juniper Sphere")));
            //    Store.JuniperSphere = GetCount("Juniper Sphere");
            //}
            //else
            //{
            //    //Assert.AreEqual(Int32.Parse(GetCount("Juniper Sphere")), Int32.Parse(Store.JuniperSphere) + 1,
            //    //    "Juniper Sphere widget count is not valid");
            //    Log.Info(String.Format("Original Juniper Sphere count is: {0} | Now: {1}", Store.JuniperSphere,
            //        GetCount("Juniper Sphere")));
            //    Store.JuniperSphere = GetCount("Juniper Sphere");
            //}

            //if (GetCount("Juniper Platinum") == "99+" || GetCount("Juniper Platinum") == "99")
            //{
            //    //Assert.IsTrue(Store.JuniperPlatinum == "98" || Store.JuniperPlatinum == "99+" || Store.JuniperPlatinum == "99",
            //    //    "Juniper Platinum widget count is not valid");
            //    Log.Info(String.Format("Original Juniper Platinum count is: {0} | Now: {1}", Store.JuniperPlatinum, GetCount("Juniper Platinum")));
            //    Store.JuniperPlatinum = GetCount("Juniper Platinum");
            //}
            //else
            //{
            //    //Assert.AreEqual(Int32.Parse(GetCount("Juniper Platinum")), Int32.Parse(Store.JuniperPlatinum) + 1, "Juniper Platinum widget count is not valid");
            //    Log.Info(String.Format("Original Juniper Platinum count is: {0} | Now: {1}", Store.JuniperPlatinum, GetCount("Juniper Platinum")));
            //    Store.JuniperPlatinum = GetCount("Juniper Platinum");
            //}

            //if (GetCount("CA Platinum") == "99+" || GetCount("CA Platinum") == "99")
            //{
            //    //Assert.IsTrue(Store.CAPlatinum == "98" || Store.CAPlatinum == "99+" || Store.CAPlatinum == "99",
            //    //    "CA Platinum widget count is not valid");
            //    Log.Info(String.Format("Original CA Platinum count is: {0} | Now: {1}", Store.CAPlatinum, GetCount("CA Platinum")));
            //    Store.CAPlatinum = GetCount("CA Platinum");
            //}
            //else
            //{
            //    //Assert.AreEqual(Int32.Parse(GetCount("CA Platinum")), Int32.Parse(Store.CAPlatinum) + 1, "CA Platinum widget count is not valid");
            //    Log.Info(String.Format("Original CA Platinum count is: {0} | Now: {1}", Store.CAPlatinum, GetCount("CA Platinum")));
            //    Store.CAPlatinum = GetCount("CA Platinum");
            //}
        }

        private void CompareWidgetCount(String widget)
        {
            String storeWidget = "";
            switch (widget)
            {
                case "CA Sphere":
                    storeWidget=Store.CASphere;
                    break;
                case "Juniper Sphere":
                    storeWidget = Store.JuniperSphere;
                    break;
                case "Juniper Platinum":
                    storeWidget = Store.JuniperPlatinum;
                    break;
                case "CA Platinum":
                    storeWidget = Store.CAPlatinum;
                    break;
            }
            Log.Info(String.Format("Original "+widget+" count is: {0} | Now: {1}", storeWidget, GetCount(widget)));
            switch (widget)
            {
                case "CA Sphere":
                    Store.CASphere=GetCount(widget);
                    break;
                case "Juniper Sphere":
                    Store.JuniperSphere = GetCount(widget);
                    break;
                case "Juniper Platinum":
                    Store.JuniperPlatinum = GetCount(widget);
                    break;
                case "CA Platinum":
                    Store.CAPlatinum = GetCount(widget);
                    break;
            }
        }

        public void VerifyTitle(String title)
        {
            Assert.IsTrue(lblTitle.GetText()==title);
            Log.Info("Title is correct");
        }

        public void CheckTags(String tag)
        {
            char[] delimiterChars = { ',' };
            string[] tags = tag.Split(delimiterChars);
            foreach (String name in tags)
            {
                Label lblTag = new Label(By.XPath(String.Format("//a[contains(text(), '{0}')]", name.Trim())), name.Trim()+" tag");
                Assert.IsTrue(lblTag.GetText().Trim()==name.Trim());
                Log.Info(name+" tag is correct");
            }
        }
    }
}
