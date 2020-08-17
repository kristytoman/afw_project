using afw_project.Model;
using afw_project.View;
using afw_project.View.Admin;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class VM_ProductMainPage : VM_Base
    {
        #region Properties
        /// <summary>
        /// Gets or sets the list of existing categories in the database.
        /// </summary>
        public ObservableCollection<Category> Categories { get; set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Creates new view-model for the product main page.
        /// </summary>
        public VM_ProductMainPage()
        {
            Categories = new ObservableCollection<Category>();
            List<Category> results = Category.GetCategories();
            if (results != null)
            {
                Categories = new ObservableCollection<Category>(results);
            }
        }
        #endregion



        #region Methods
        /// <summary>
        /// Open a page for new product.
        /// </summary>
        public void GetNewProductPage()
        {
            if (ContextCredentials.CheckTheAdmin(App.User.Email,App.User.Password))
            {
                ((MainPage)Application.Current.MainPage).Detail = new ProductForm();
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
                children.Add(new View.Admin.Products("All"));
                foreach (Category category in Categories)
                {

                    children.Add(new View.Admin.Products(category.Name));
                }
            }
            else
            {
                children.Add(new View.Customer.Products("All"));
                foreach (Category category in Categories)
                {

                    children.Add(new View.Customer.Products(category.Name));
                }
            }
        }
        #endregion
    }
}
