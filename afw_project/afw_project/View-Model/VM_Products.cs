using afw_project.Model;
using afw_project.View.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    public class ProductView : VM_Base
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Price { get; set; }
        public string Sale { get; set; }
        public string FinalPrice { get; set; }
        private readonly string shortDescription;
        private readonly string longDescription;
        public string Description 
        { 
            get 
            { 
                if (isSelected) return longDescription;
                return shortDescription; 
            } 
        }
        private bool isSelected;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                    OnPropertyChanged();
                
            }
        }

        public string Category { get; set; }

        public ProductView(Product template)
        {
            ID = template.ID;
            Name = template.Name;
            Amount = template.Amount.ToString();
            Price = template.Price.ToString() + " EUR";
            Sale = template.Sale != 0 ? template.Sale.ToString() + " %" : "";
            Category = "";
            shortDescription = template.Description.Substring(0, template.Description.Length < 50 ? template.Description.Length : 50);
            longDescription = template.Description;
            FinalPrice = Math.Round((double)(template.Price - template.Price * template.Sale / 100), 2).ToString();
            isSelected = false;

        }
        public ProductView(Product template, int amount,int sale) : this(template)
        {
            Amount = amount.ToString();
            Sale = sale.ToString();

        }
    }
    class VM_Products : VM_Base
    {
        /// <summary>
        /// List of products from a database.
        /// </summary>
        private ObservableCollection<ProductView> productsList;

        /// <summary>
        /// Page category. Null if content page is for all products.
        /// </summary>
        private readonly Category category;


        /// <summary>
        /// Creates new view-model for a product page and gets the products.
        /// </summary>
        /// <param name="title">Name of the page.</param>
        public VM_Products(string title)
        {
            List<ProductView> results;

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
                productsList = new ObservableCollection<ProductView>();
            }
            else
            {
                productsList = new ObservableCollection<ProductView>(results);
            }

            
        }

        public void DeleteSelectedItem(ProductView item)
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
                    ((View_MainPage)Application.Current.MainPage).Detail = new View_Products();
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

        public void AddToCart(int id)
        {
            
        }
        

        /// <summary>
        /// Gets or sets the list of products from the database.
        /// </summary>
        public ObservableCollection<ProductView> ProductsList
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
