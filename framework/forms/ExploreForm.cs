using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProductX.Framework;
using ProductX.Framework.Elements;
using ProductX.Framework.Forms;

namespace ProductX.framework.forms
{
    public class ExploreForm : BaseForm
    {
        private static By TitleLocator = By.XPath("//p[contains(text(), 'Create interest')]"); 
        public ExploreForm() : base(TitleLocator, "Explore form")
        {
        }

       
        private readonly Button btnBoom = new Button(By.XPath("//span[contains(text(), 'Link Highlight Issue')]"), "TEst button");
        
       

        public void ClickTest()
        {
            btnBoom.Click();
        }
    }
    
}
