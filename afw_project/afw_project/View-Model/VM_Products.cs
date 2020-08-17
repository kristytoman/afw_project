using afw_project.Model;
using afw_project.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class VM_Products : VM_Base
    {
        #region Properties
        /// <summary>
        /// Gets or sets the list of products from the database.
        /// </summary>
        public ObservableCollection<ProductItem> ProductsList { get; set; }

        /// <summary>
        /// Page category. Null if content page is for all products.
        /// </summary>
        private readonly Category category;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates new view-model for a product page and gets the products.
        /// </summary>
        /// <param name="title">Name of the page.</param>
        public VM_Products(string title)
        {
            List<ProductItem> results;

            if (title == "All")
            {
                results = Product.GetAll();
            }
            else
            {
                category = new Category(title);
                results = category.GetProducts();
            }
            if (results == null)
            {
                ProductsList = new ObservableCollection<ProductItem>();
            }
            else
            {
                ProductsList = new ObservableCollection<ProductItem>(results);
            }
        }
        #endregion

        #region Method
        public void DeleteSelectedItem(ProductItem item)
        {
            if (ContextCredentials.CheckTheAdmin(App.User.Email, App.User.Password))
            {
                if(Product.DeleteProduct(item.ID))
                {
                    Application.Current.MainPage.DisplayAlert
                    (
                       "Succesful operation",
                       "Product was marked as deleted",
                       "OK"
                    );
                    ((MainPage)Application.Current.MainPage).Detail = new Products_MainPage();
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert
                    (
                       "Something went wrong",
                       "We were unable to delete the product",
                       "OK"
                    );
                }
            }
        }
        #endregion
    }
}
