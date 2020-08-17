using afw_project.View_Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View.Customer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cart : ContentPage
    {
        /// <summary>
        /// Creates a new page for a customer cart content.
        /// </summary>
        public Cart()
        {
            BindingContext = new VM_Cart();
            InitializeComponent();
        }
    }
}