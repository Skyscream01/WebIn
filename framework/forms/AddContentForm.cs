using System;
using OpenQA.Selenium;
using ProductX.Framework.Elements;
using ProductX.Framework.Forms;

namespace ProductX.framework.forms
{
    public class AddContentForm : BaseForm
    {
        private static By TitleLocator = By.XPath("//div[contains(text(), 'add some content, first step; what sort of content?')]");
        public AddContentForm() : base(TitleLocator, "Add Content form")
        {
        }
        private readonly Button btnNextAddTitle = new Button(By.XPath("//a//*[contains(text(), 'Next: Add your title')]"), "'Next: Add your title' button");
        private readonly TextBox tbTitle = new TextBox(By.XPath("//div[contains(@data-test-id, 'contentCreateStep1-title')]"), "Title textbox");
        private readonly Button btnNextRelatedContent = new Button(By.XPath("//div[contains(@class, 'ui-x-active')]//a[@class='ui-x-accordion-btn']/*[contains(text(), 'Next: Related Content')]"), "Next: Related Content button");
        private readonly Button btnNextCategorizeContent = new Button(By.XPath("//div[contains(@class, 'ui-x-active')]//a[@class='ui-x-accordion-btn']/*[contains(text(), 'Next: Categorise your content')]"), "Next: Categorize button");
        private readonly Label lblExploreTagsBox = new Label(By.XPath("//*[contains(@ref, 'TAGEXPLORER-SEARCHFORTAGS')]"), "Explore tags label");
        private readonly TextBox tbExploreTags = new TextBox(By.XPath("//input[contains(@ng-keyup, 'getTags()')]"), "Explore tags textbox");
        private readonly Label lblExploreAudienceTagsBox = new Label(By.XPath("//div[contains(@xd-tag-explorer-selected-tag-objects, 'selectedAudienceTags')]//*[contains(@ref, 'TAGEXPLORER-SEARCHFORTAGS')]"), "Explore tags label");
        private readonly TextBox tbExploreAudienceTags = new TextBox(By.XPath("//div[contains(@xd-tag-explorer-selected-tag-objects, 'selectedAudienceTags')]//input[contains(@ng-keyup, 'getTags()')]"), "Explore tags textbox");
        private readonly Button btnNextSearchTerms = new Button(By.XPath("//div[contains(@class, 'ui-x-active')]//a[@class='ui-x-accordion-btn']/*[contains(text(), 'Next: Search Terms')]"), "Next: Search Terms button");
        private readonly Button btnNextAddAdditionalInfo = new Button(By.XPath("//div[contains(@class, 'ui-x-active')]//a[@class='ui-x-accordion-btn']/*[contains(text(), 'Next: Add additional')]"), "Next: Add Additional Information");
        private readonly Button btnNextReviewAndPublish = new Button(By.XPath("//div[contains(@class, 'ui-x-active')]//a[@class='ui-x-accordion-btn']/*[contains(text(), 'Next: Review & Publish')]"), "Next: Review And Publish button");
        private readonly Button btnComplete = new Button(By.XPath("//div[contains(@class, 'ui-x-active')]//a[@class='ui-x-accordion-btn']/*[contains(text(), 'Finish')]"), "Complete button");
        private readonly Button btnNextSelectSpheres = new Button(By.XPath("//div[contains(@class, 'ui-x-active')]//a[@class='ui-x-accordion-btn']/*[contains(text(), 'Next: Select spheres')]"), "Next: Select Spheres button");
        private readonly Button btnNextWhoCanSeeButton = new Button(By.XPath("//div[contains(@class, 'ui-x-active')]//a[@class='ui-x-accordion-btn']/*[contains(text(), 'Next: Who can see')]"), "Next: Who can see this article button");

        public void SelectContentType(String type)
        {
            Button btnType = new Button(By.XPath(String.Format("//span[contains(text(), '{0}')]", type)), type+" type button");
            btnType.Click();
        }

        public void ClickNextAddTitleButton()
        {
            btnNextAddTitle.Click();
        }

        public void SetTitle(string title)
        {
            tbTitle.ClearSetText(title);
        }

        public void ClickNextRelatedContentButton()
        {
            btnNextRelatedContent.Click();
        }

        public void ClickNextCategorizeButton()
        {
            btnNextCategorizeContent.Click();
        }

        public void InitiateTagsSearch()
        {
            lblExploreTagsBox.Click();
        }

        public void SetExploreTag(string tag)
        {
            char[] delimiterChars = { ',' };
            string[] tags = tag.Split(delimiterChars);
            foreach (String name in tags)
            {
                tbExploreTags.ClearSetText(name);
                Button Tag = new Button(By.XPath(string.Format("//em[text()='{0}']", name.Trim())), name.Trim() + " tag tooltip");
                Tag.Click();
            }
        }
        public void InitiateAudienceTagsSearch()
        {
            lblExploreAudienceTagsBox.Click();
        }

        public void SetExploreAudienceTag(string tag)
        {
            char[] delimiterChars = { ',' };
            string[] tags = tag.Split(delimiterChars);
            foreach (String name in tags)
            {
                tbExploreAudienceTags.ClearSetText(name);
                Label Tag = new Label(By.XPath(string.Format("//em[text()='{0}']", name.Trim())), name.Trim() + " tag tooltip");
                Tag.Click();
            }
        }
        public void SelectTag(string name)
        {
            char[] delimiterChars = { ',' };
            string[] tags = name.Split(delimiterChars);
            foreach (String tag in tags)
            {
                Button btnTag =
                    new Button(
                        By.XPath(
                            String.Format(
                                "//div[contains(text(), '{0}')][contains(@class, 'ui-x-expandable-grid-list-gridItem-title' )]",
                                tag.Trim())), tag.Trim() + " tag");
                btnTag.Click();
            }
        }

        public void ClickNextSearchTermsButton()
        {
            btnNextSearchTerms.Click();
        }

        public void ClickNextAddAdditionalInfoButton()
        {
            btnNextAddAdditionalInfo.Click();
        }

        public void ClickNextReviewAndPublishButton()
        {
            btnNextReviewAndPublish.Click();
        }

        public void ClickCompleteButton()
        {
            btnComplete.Click();
        }

        public void ClickNextSelectSpheresButton()
        {
            btnNextSelectSpheres.Click();
        }

        public void ClickNextWhoCanSeeButton()
        {
            btnNextWhoCanSeeButton.Click();
        }

    }
}
