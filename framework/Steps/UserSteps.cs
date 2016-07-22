using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductX.framework.forms;
using ProductX.framework.forms.ContentForms;
using ProductX.framework.forms.ContentForms.FilePickerForms;
using ProductX.Framework;

namespace ProductX.framework.Steps
{
    public class UserSteps : BaseEntity
    {
        private MainForm _mainForm;
        private ExploreForm _exploreForm;
        private AddContentForm _addContentForm;
        private SearchResultsForm _searchResultsForm;
        private ContentForm _contentForm;
        private AddDocumentForm _addDocumentForm;
        private FilePickerForm _filePickerForm;
        private GoogleAuth _googleAuth;
        private SecurityForm _securityForm;

        public SecurityForm AtSecurityForm()
        {
            return _securityForm = new SecurityForm();
        }

        public GoogleAuth AtGoogleAuthForm()
        {
            return _googleAuth = new GoogleAuth();
        }

        public MainForm AtMainForm()
        {
                _mainForm = new MainForm();
                return _mainForm;
        }
        public FilePickerForm AtFilePickerMainForm()
        {
              return _filePickerForm = new FilePickerForm();
        }
     
        public AddDocumentForm AtAddDocumentForm()
        {
            _addDocumentForm = new AddDocumentForm();
            return _addDocumentForm;
        }

        public ExploreForm AtExploreForm()
        {
            _exploreForm = new ExploreForm();
            return _exploreForm;
        }
        public AddContentForm AtAddContentForm()
        {
            _addContentForm = new AddContentForm();
            return _addContentForm;
        }
        public SearchResultsForm AtSearchResultsForm()
        {
            _searchResultsForm = new SearchResultsForm();
            return _searchResultsForm;
        }
        public ContentForm AtContentForm()
        {
            _contentForm = new ContentForm();
            return _contentForm;
        }
    }
}
