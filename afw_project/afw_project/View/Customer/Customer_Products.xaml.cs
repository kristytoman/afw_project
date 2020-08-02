using afw_project.View_Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Customer_Products : ContentPage
    {
       /// <summary>
       /// Creates new page for the products.
       /// </summary>
       /// <param name="name">Title name.</param>
        public Customer_Products(string name)
        {
            Title = name;
            InitializeComponent();

            BindingContext = new VM_Products(Title);
        }
    }
}
