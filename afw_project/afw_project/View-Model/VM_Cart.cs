using afw_project.Model;
using afw_project.View;
using afw_project.View.Customer;
using afw_project.View_Model.Sales;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class VM_Cart : VM_Base
    {
        #region Properties and fields
        /// <summary>
        /// List of cart items.
        /// </summary>
        public ObservableCollection<CartItem> Cart_products { get; set; }

        /// <summary>
        /// The cost of order without sale.
        /// </summary>
        private double elementaryCost;
        /// <summary>
        /// Bindable property that gets or sets the summed price of all the products without any sale.
        /// </summary>
        public double ElementaryCost
        {
            get => elementaryCost;
            private set
            {
                if (value != elementaryCost)
                {
                    elementaryCost = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Total cost of all the wanted items.
        /// </summary>
        private double finalCost;
        /// <summary>
        /// Gets or sets the total cost of all wanted items.
        /// </summary>
        public double FinalCost
        {
            get
            {
                return finalCost;
            }
            private set
            {
                if (value != finalCost)
                {
                    finalCost = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Command to finish the order.
        /// </summary>
        public Command Continue { get; set; }
        #endregion
        public Price Price { get; set; }

        #region Constructor
        /// <summary>
        /// Creates new view-model for the customer's cart.
        /// </summary>
        public VM_Cart()
        {
            FinalCost = 0;
            Price = (Price)Activator.CreateInstance(App.SaleSeason, App.User.GetCart().ProductOrders,this);
            Cart_products = Price.GetSale();
            SetTheCosts();
            Continue = new Command(SaveChanges);
        }
        #endregion



        #region Methods

        /// <summary>
        /// Sets new values for the bindable properties of the order.
        /// </summary>
        public void SetTheCosts()
        {
            FinalCost = Price.NewPrice;
            ElementaryCost = Price.ElementaryPrice;
        }



        /// <summary>
        /// Save the final amount of the products to order.
        /// </summary>
        private void SaveChanges()
        {
            if (App.User.Password != null && App.User.Password != string.Empty)
            {
                if (App.User.SendTheOrder(Price.NewPrice))
                    App.User.Orders.Add(Order.CreateNewCart());
                ((MainPage)Application.Current.MainPage).Detail = new Products_MainPage();
            }
            else
            {
                App.User.GetCart().Price = Price.NewPrice;
                ((MainPage)Application.Current.MainPage).Detail = new CustomerForm(false);
            }
        }

        #endregion
    }
}
