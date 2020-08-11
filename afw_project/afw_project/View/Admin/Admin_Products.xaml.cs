using afw_project.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Admin_Products : ContentPage
    {
        VM_Products viewModel;
        public Admin_Products(string name)
        {
            Title = name;
            InitializeComponent();
            viewModel = new VM_Products(Title);
            BindingContext = viewModel;
        }

        ProductView selectedItem;
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
            if (!(lw.SelectedItem is ProductView item))
            {
                return;
            }
            item.IsSelected = true;
            selectedItem = item;
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            ((View_MainPage)(Parent.Parent)).Detail = new Admin_ProductForm(selectedItem);
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            viewModel.DeleteSelectedItem(selectedItem);
        }
    }
}