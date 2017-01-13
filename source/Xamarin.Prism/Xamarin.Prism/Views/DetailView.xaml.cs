using Prism.Navigation;
using Xamarin.Forms;

namespace Xamarin.Prism.Views
{
    /// <summary>
    /// Used as base navigation page for MasterDetail
    /// </summary>
    public partial class DetailView : NavigationPage, INavigationPageOptions
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
