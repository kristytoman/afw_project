using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class CartItem : VM_Base
    {
        /// <summary>
        /// view model connected to the cart item.
        /// </summary>
        private VM_Cart viewModel;

        /// <summary>
        /// Gets or sets the ID of the product in the cart.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Gets or sets the name of the product in the cart.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Amount of ordered goods of this type.
        /// </summary>
        private int amount;

        /// <summary>
        /// Gets or sets the mount of ordered goods of this type.
        /// </summary>
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (value != amount)
                {
                    double before = FinalPrice;
                    amount = value;
                    SummedPrice = originalPrice * value;
                    FinalPrice = Math.Round((double)(SummedPrice - SummedPrice * Sale / 100), 2);
                    viewModel.ChangeCost(FinalPrice - before);
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Original price of one product.
        /// </summary>
        private double originalPrice;

        /// <summary>
        /// Original cost of the ordered goods.
        /// </summary>
        private double summedPrice;

        /// <summary>
        /// Gets or sets the original cost of the ordered goods.
        /// </summary>
        public double SummedPrice
        {
            get
            {
                return summedPrice;
            }
            private set
            {
                if (value != summedPrice)
                {
                    summedPrice = value;
                    OnPropertyChanged();
                }
            }

        }

        /// <summary>
        /// Gets or sets the sale of the product in the cart.
        /// </summary>
        public int Sale { get; private set; }

        /// <summary>
        /// Total price of all products with a sale.
        /// </summary>
        private double finalPrice;

        /// <summary>
        /// Gets or sets the total price of all products with a sale.
        /// </summary>
        public double FinalPrice
        {
            get
            {
                return finalPrice;
            }
            set
            {
                if (value != finalPrice)
                {
                    finalPrice = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Creates a new cart item and count the price.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        /// <param name="price"></param>
        /// <param name="sale"></param>
        public CartItem(VM_Cart viewModel, int id, string name, int amount, int price, int sale)
        {
            this.viewModel = viewModel;
            ID = id;
            Name = name;
            originalPrice = price;
            this.amount = amount;
            SummedPrice = originalPrice * Amount;
            Sale = sale;
            FinalPrice = Math.Round((double)(SummedPrice - SummedPrice * Sale / 100), 2);
        }

        /// <summary>
        /// Sends the new amount of the item to the model.
        /// </summary>
        public void ChangeTheAmount()
        {
            App.Cart.ChangeAmountOfProduct(App.User.Password != null || App.User.Password != string.Empty, ID, Amount);
        }
    }



    class VM_Cart : VM_Base
    {
        /// <summary>
        /// List of cart items.
        /// </summary>
        public ObservableCollection<CartItem> Cart_products { get; set; }

        /// <summary>
        /// Command to finish the order.
        /// </summary>
        public Command Continue { get; set; }

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
        /// Creates new view-model for the customer's cart.
        /// </summary>
        public VM_Cart()
        {
            List<ProductOrder> output = App.Cart.GetOrderProducts();
            FinalCost = 0;
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
            }
        }
    }
}
