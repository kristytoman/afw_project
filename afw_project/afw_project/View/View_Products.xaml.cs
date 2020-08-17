using afw_project.Model;
using afw_project.View_Model;
using Xamarin.Forms.Xaml;

namespace afw_project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View_Products : Xamarin.Forms.TabbedPage
    {
        /// <summary>
        /// View-model of the Tabbed page of products.
        /// </summary>
        VM_ProductMainPage viewModel;

        /// <summary>
        /// Main page for showing all products for admin and customer.
        /// 
        /// Creates subpages containing all categories and products.
        /// </summary>
        public View_Products()
        {
            /// Creates a new view-model.
            viewModel = new VM_ProductMainPage();
            BindingContext = viewModel;
            if (ContextCredentials.CheckTheAdmin(App.User.Email, App.User.Password))
            {
                Title = "Your products";
                ToolbarItems.Add(new Xamarin.Forms.ToolbarItem("Add", "", viewModel.GetNewProductPage));
            }

            InitializeComponent();
            
            /// Creates tabs for all inherited pages.
            viewModel.GetPages(Children);
        }
    }
}