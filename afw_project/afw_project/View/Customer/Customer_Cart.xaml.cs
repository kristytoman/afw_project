using afw_project.View.Admin;
using afw_project.View_Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Customer_Cart : ContentPage
    {
        /// <summary>
        /// Creates a new page for a customer cart content.
        /// </summary>
        public Customer_Cart()
        {
            BindingContext = new VM_Cart();
            InitializeComponent();
        }
    }
}