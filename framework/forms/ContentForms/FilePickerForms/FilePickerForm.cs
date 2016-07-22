using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProductX.Framework.Elements;
using ProductX.Framework.Forms;

namespace ProductX.framework.forms.ContentForms
{
    
   public class FilePickerForm : BaseForm
   {
       private static readonly By TitleLocator = By.XPath("//p[contains(text(), 'Choose File')]");
        public FilePickerForm() : base(TitleLocator, "FilePicker Form")
        {
        }
        private readonly Button btnGoogleDrive = new Button(By.XPath("//a[contains(@ng-href, 'GoogleDrive')]"), "Google Drive link");
        private readonly Link lnkConnectToGoogleDrive = new Link(By.XPath("//a[contains(text(), 'Connect to Google Drive')]"), "Connect to Google Drive link");

       public void SelectGoogleDrive()
       {
            btnGoogleDrive.Click();
       }

       public void ClickConnectToGoogleDrive()
       {
            lnkConnectToGoogleDrive.Click();
       }

       public void SelectFile(String file)
       {
            Button btnFile=new Button(By.XPath(String.Format("//span[contains(text(), '{0}')]/parent::*", file)), file+" file button");
            btnFile.Click();
       }
       
   }
}
