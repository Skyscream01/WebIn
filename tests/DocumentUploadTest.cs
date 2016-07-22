using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductX.Framework;
using NUnit.Framework;
using ProductX.framework;

namespace ProductX.tests
{
    class DocumentUploadTest : BaseTest
    {
        [Test]
        public void DocumentTest()
        {
            User.AtMainForm().SwitchToAuthFrame();
            User.AtMainForm().SetUserName("denis.kolkovskiy@itechart-group.com");
            User.AtMainForm().SetPassword("Test_123");
            User.AtMainForm().ClickLogin();
            User.AtExploreForm().PerformSearch("Count Widgets");
            User.AtSearchResultsForm().OpenSearchItem("Count Widgets");
            User.AtContentForm().StoreWidgetsCount();
            User.AtContentForm().ClickAddContent();
            User.AtContentForm().AtCreateContentPane().SelectPublishType("Graphics News");
            User.AtAddContentForm().SelectContentType("Document");
            User.AtAddContentForm().ClickNextAddTitleButton();
            User.AtAddDocumentForm().SwitchToLastWindow();
            User.AtFilePickerMainForm().SelectGoogleDrive();
            User.AtFilePickerMainForm().ClickConnectToGoogleDrive();
            User.AtGoogleAuthForm().SetLogin("it.eugeny.belyaev@gmail.com");
            User.AtGoogleAuthForm().ClickNext();
            User.AtGoogleAuthForm().SetPassword("mazda6593006");
            User.AtGoogleAuthForm().ClickSignIn();
            User.AtSecurityForm().ClickAllow();
            User.AtFilePickerMainForm().SelectGoogleDrive();
            User.AtFilePickerMainForm().SelectFile("Getting started");
            User.AtFilePickerMainForm().SwitchToMain();
            User.AtAddDocumentForm().WaitTillFileUpload();
            User.AtAddDocumentForm().SetTitle("Low profile slot");
            User.AtAddDocumentForm().ClickNextRelatedContentButton();
            User.AtAddDocumentForm().ClickNextCategorizeButton();
            User.AtAddDocumentForm().InitiateTagsSearch();
            User.AtAddDocumentForm().SetExploreTag("Low Profile");
            User.AtAddDocumentForm().ClickNextAddAdditionalInfoButton();
            User.AtAddDocumentForm().ClickNextReviewAndPublishButton();
            User.AtAddDocumentForm().ClickCompleteButton();
            User.AtContentForm().VerifyTitle("Low profile slot");
            User.AtContentForm().PerformSearch("Count Widgets");
            User.AtSearchResultsForm().OpenSearchItem("Count Widgets");
            User.AtContentForm().AssertWidgetsCount();
            GoogleConfigurator.StoreData("Results!A4:D4");
        }
    }
}
