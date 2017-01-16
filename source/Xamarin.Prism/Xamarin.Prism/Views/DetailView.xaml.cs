using Prism.Navigation;

namespace Xamarin.Prism.Views
{
    /// <summary>
    /// Used as base navigation page for MasterDetail
    /// </summary>
    public partial class DetailView : INavigationPageOptions
    {
        public DetailView()
        {
            InitializeComponent();
        }

        public bool ClearNavigationStackOnNavigation
        {
            get { return true; }
        }
    }
}
