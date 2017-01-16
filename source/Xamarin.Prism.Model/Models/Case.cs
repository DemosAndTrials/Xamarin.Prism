using Xamarin.Prism.Model.Contracts.Models;
using Xamarin.Prism.Model.Models.Abstract;

namespace Xamarin.Prism.Model.Models
{
    /// <summary>
    /// https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_objects_case.htm
    /// </summary>
    public class Case : ModelBase, ICase
    {
        private string _caseNumber;
        private string _origin;
        private string _ownerId;
        private string _reason;
        private string _description;
        private string _priority;
        private string _status;
        private string _subject;

        public string CaseNumber
        {
            get { return _caseNumber; }
            set { SetProperty(ref _caseNumber, value); }
        }

        public string Origin
        {
            get { return _origin; }
            set { SetProperty(ref _origin, value); }
        }

        public string OwnerId
        {
            get { return _ownerId; }
            set { SetProperty(ref _ownerId, value); }
        }

        public string Reason
        {
            get { return _reason; }
            set { SetProperty(ref _reason, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public string Priority
        {
            get { return _priority; }
            set { SetProperty(ref _priority, value); }
        }

        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        public string Subject
        {
            get { return _subject; }
            set { SetProperty(ref _subject, value); }
        }
    }
}
