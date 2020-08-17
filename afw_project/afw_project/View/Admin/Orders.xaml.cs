using afw_project.View_Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Orders : ContentPage
    {
        #region Constructor
        /// <summary>
        /// Creates a new page for viewing orders.
        /// </summary>
        /// <param name="name">Title of the page.</param>
        public Orders(string name)
        {
            Title = name;
            InitializeComponent();
            BindingContext = new VM_Orders_Admin(name);
        }
        #endregion
    }
}