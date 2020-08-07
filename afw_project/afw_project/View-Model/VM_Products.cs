using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace afw_project.View_Model
{
    class VM_Products : VM_Base
    {
        /// <summary>
        /// List of products from a database.
        /// </summary>
        private ObservableCollection<Product> productsList;

        /// <summary>
        /// Page category. Null if content page is for all products.
        /// </summary>
        private Category category;


        /// <summary>
        /// Creates new view-model for a product page and gets the products.
        /// </summary>
        /// <param name="title">Name of the page.</param>
        public VM_Products(string title)
        {
            List<Product> results;

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
                productsList = new ObservableCollection<Product>();
            }
            else
            {
                productsList = new ObservableCollection<Product>(results);
            }
        }

        

        /// <summary>
        /// Gets or sets the list of products from the database.
        /// </summary>
        public ObservableCollection<Product> ProductsList
        {
            get
            {
                return productsList;
            }
            set
            {
                if (productsList != value)
                {
                    productsList = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
