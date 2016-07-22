using System.Threading;
using NUnit.Framework;
using ProductX.framework;
using ProductX.framework.forms;
using ProductX.Framework;

namespace ProductX.tests
{
    class Test : BaseTest
    {
        [Test]
        public void RunTest()
        {
            User.AtMainForm().SwitchToAuthFrame();
            User.AtMainForm().SetUserName("denis.kolkovskiy@itechart-group.com");
            User.AtMainForm().SetPassword("Test_123");
            User.AtMainForm().ClickLogin();
            GoogleConfigurator.GetData();
            User.AtMainForm().PerformSearch("Count Widgets");
            User.AtSearchResultsForm().OpenSearchItem("Count Widgets");
            User.AtContentForm().StoreWidgetsCount();
            for (int i = 0; i < 4; i++)
            {
                User.AtContentForm().ClickAddContent();
                User.AtContentForm().AtCreateContentPane().SelectPublishType("3 spheres");
                User.AtContentForm().AtCreateContentPane().SelectPublishType("Premium access");
                User.AtAddContentForm().SetTitle(Store.Name[i]);
                User.AtAddContentForm().ClickNextRelatedContentButton();
                User.AtAddContentForm().ClickNextSelectSpheresButton();
                User.AtAddContentForm().SelectTag(Store.Sphere[i]);
                User.AtAddContentForm().ClickNextCategorizeButton();
                User.AtAddContentForm().InitiateTagsSearch();
                User.AtAddContentForm().SetExploreTag(Store.Category[i]);
                User.AtAddContentForm().ClickNextSearchTermsButton();
                User.AtAddContentForm().ClickNextWhoCanSeeButton();
                User.AtAddContentForm().InitiateAudienceTagsSearch();
                User.AtAddContentForm().SetExploreAudienceTag(Store.Audience[i]);
                User.AtAddContentForm().ClickNextAddAdditionalInfoButton();
                User.AtAddContentForm().ClickNextReviewAndPublishButton();
                User.AtAddContentForm().ClickCompleteButton();
                User.AtContentForm().VerifyTitle(Store.Name[i]);
                User.AtContentForm().CheckTags(Store.Category[i]);
            }
           User.AtContentForm().PerformSearch("Count Widgets");
           User.AtSearchResultsForm().OpenSearchItem("Count Widgets");
           User.AtContentForm().AssertWidgetsCount();
           GoogleConfigurator.StoreData("Results!A2:D2");
        }
    }
}
