using afw_project.View.Admin;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class VM_ProductMainPage : VM_Base
    {
        /// <summary>
        /// List of existing categories in the database.
        /// </summary>
        private ObservableCollection<Category> categories;

        /// <summary>
        /// Gets or sets the list of existing categories in the database.
        /// </summary>
        public ObservableCollection<Category> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                if (categories!=value)
                {
                    categories = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Creates new view-model for the product main page.
        /// </summary>
        public VM_ProductMainPage()
        {
            categories = new ObservableCollection<Category>(Category.GetCategories());
        }

        /// <summary>
        /// Open a page for new product.
        /// </summary>
        public void GetNewProductPage()
        {
            if (VM_Login.LoggedUser.Email == "admin")
            {
                ((View_MainPage)App.Current.MainPage).Detail = new Admin_NewProduct();
            }
        }

        /// <summary>
        /// Gets content pages for a main product page.
        /// </summary>
        /// <param name="children">List of children pages of a main product page.</param>
        public void GetPages(IList<Page> children)
        {
            if (VM_Login.LoggedUser != null && VM_Login.LoggedUser.Email == "admin")
            {
                children.Add(new Admin_Products("All"));
                foreach (Category category in Categories)
                {

                    children.Add(new Admin_Products(category.Name));
                }
            }
            else
            {
                children.Add(new Customer_Products("All"));
                foreach (Category category in Categories)
                {

                    children.Add(new Customer_Products(category.Name));
                }
            }
        }

    }
}
