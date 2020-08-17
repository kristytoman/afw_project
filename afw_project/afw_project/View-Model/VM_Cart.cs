using afw_project.Model;
using afw_project.View;
using afw_project.View.Customer;
using System.Collections.Generic;
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


        #region Constructor
        /// <summary>
        /// Creates new view-model for the customer's cart.
        /// </summary>
        public VM_Cart()
        {
            FinalCost = 0;

            List<ProductOrder> output = App.Cart.GetOrderProducts();
            Cart_products = new ObservableCollection<CartItem>();
            if (output != null)
            {
                foreach (ProductOrder orderedProduct in output)
                {
                    Cart_products.Add
                    (
                        new CartItem
                        (
                            this, 
                            orderedProduct.Product.ID, 
                            orderedProduct.Product.Name, 
                            orderedProduct.Amount, 
                            orderedProduct.Product.Price, 
                            orderedProduct.Sale
                        )
                    );
                    ChangeCost(Cart_products[Cart_products.Count - 1].FinalPrice);
                }

                Continue = new Command(SaveChanges);
            }
        }
        #endregion



        #region Methods
        /// <summary>
        /// Changes the total cost of the order.
        /// </summary>
        /// <param name="difference">Number to add to the total cost.</param>
        public void ChangeCost(double difference)
        {
            if (FinalCost + difference > 0)
            {
                FinalCost += difference;
            }
        }



        /// <summary>
        /// Save the final amount of the products to order.
        /// </summary>
        private void SaveChanges()
        {
            foreach(CartItem item in Cart_products)
            {
                item.ChangeTheAmount();
            }

            if (App.User.Password != null && App.User.Password != string.Empty)
            {
                App.Cart.SendTheOrder();
                App.Cart = new Order { Customer = App.User };
                ((MainPage)Application.Current.MainPage).Detail = new Products_MainPage();

            }
            else
            {
                ((MainPage)Application.Current.MainPage).Detail = new CustomerForm(false);
            }
        }
        #endregion
    }
}
