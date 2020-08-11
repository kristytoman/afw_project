using afw_project.Model;
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
            categories = new ObservableCollection<Category>();
            List<Category> results = Category.GetCategories();
            if (results != null)
            {
                categories = new ObservableCollection<Category>(results);
            }
        }

        /// <summary>
        /// Open a page for new product.
        /// </summary>
        public void GetNewProductPage()
        {
            if (ContextCredentials.CheckTheAdmin(App.User.Email,App.User.Password))
            {
                ((View_MainPage)Application.Current.MainPage).Detail = new Admin_ProductForm();
            }
        }

        /// <summary>
        /// Gets content pages for a main product page.
        /// </summary>
        /// <param name="children">List of children pages of a main product page.</param>
        public void GetPages(IList<Page> children)
        {
            if (ContextCredentials.CheckTheAdmin(App.User.Email, App.User.Password))
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
