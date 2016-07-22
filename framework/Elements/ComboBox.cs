using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ProductX.Framework.Elements
{
    public class ComboBox : BaseElement
    {
        private SelectElement _select;

        public ComboBox(By locator, string name)
            : base(locator, name)
        {
        }

// Selects item from drop-down list by label
        public void SelectByLabel(string label)
        {
            WaitForElementPresent();
            Log.Info(string.Format("selecting option by text '{0}'", label));
            _select = new SelectElement(GetElement());
            _select.SelectByText(label);
        }

// Selects item from drop-down list by attribute value
        public void SelectByValue(string value)
        {
            WaitForElementPresent();
            Log.Info(string.Format("selecting option by value '{0}'", value));
            _select = new SelectElement(GetElement());
            _select.SelectByValue(value);
        }

// Selects item from drop-down list by int index
        public void SelectByIndex(int index)
        {
            WaitForElementPresent();
            Log.Info(string.Format("selecting option by index '{0}'", index));
            _select = new SelectElement(GetElement());
            _select.SelectByIndex(index);
        }
    }
}
