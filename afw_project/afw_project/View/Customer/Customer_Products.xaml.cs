using afw_project.View_Model;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
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
        ProductView selectedItem;
        private void Products_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var lw = sender as ListView;
            if (lw == null)
            {
                return;
            }

            if (selectedItem != null)
            {
                selectedItem.IsSelected = false;
            }
            ProductView item = lw.SelectedItem as ProductView;
            if (item == null)
            {
                return;
            }
            item.IsSelected = true;
            selectedItem = item;
        }
    }
}
