using System;
using Prism.Mvvm;

namespace Xamarin.Prism.Model.Models.Abstract
{
    public abstract class ModelBase : BindableBase
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private DateTime _lastModifiedDate;
        public DateTime LastModifiedDate
        {
            get { return _lastModifiedDate; }
            set { SetProperty(ref _lastModifiedDate, value); }
        }
    }
}
