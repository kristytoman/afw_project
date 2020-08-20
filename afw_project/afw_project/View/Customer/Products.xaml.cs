using afw_project.View_Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View.Customer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Products : ContentPage
    {
       /// <summary>
       /// Creates new page for the products.
       /// </summary>
       /// <param name="name">Title name.</param>
        public Products(string name)
        {
            Title = name;
            InitializeComponent();

            BindingContext = new VM_Products(Title);
        }
        ProductItem selectedItem;
        private void Products_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(sender is ListView lw))
            {
                return;
            }

            if (selectedItem != null)
            {
                selectedItem.IsSelected = false;
            }
            if (!(lw.SelectedItem is ProductItem item))
            {
                return;
            }
            item.IsSelected = true;
            selectedItem = item;
        }

        private void AddToCart_Clicked(object sender, System.EventArgs e)
        {
            if (!App.User.GetCart().AddProduct(selectedItem.ID))
            {
                DisplayAlert("Something went wrong", "We were unable to put this item in the cart", "OK");
            }
        }
    }
}
