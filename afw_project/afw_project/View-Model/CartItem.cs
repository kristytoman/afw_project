using System;

namespace afw_project.View_Model
{
    internal class CartItem : VM_Base
    {
        /// <summary>
        /// view model connected to the cart item.
        /// </summary>
        private readonly VM_Cart viewModel;

        #region Item properties
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
        private readonly double originalPrice;

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
        #endregion


        /// <summary>
        /// Creates a new cart item and count the price.
        /// </summary>
        /// <param name="viewModel">View-model of the current cart page.</param>
        /// <param name="id">ID of the product.</param>
        /// <param name="name">Name of the product.</param>
        /// <param name="amount">Amount of the ordered product.</param>
        /// <param name="price">Original price of the product.</param>
        /// <param name="sale">Sale of the product.</param>
        public CartItem(VM_Cart viewModel, int id, string name, int amount, int price, int sale)
        {
            this.viewModel = viewModel;

            ID = id;
            Name = name;
            originalPrice = price;
            this.amount = amount;
            Sale = sale;

            SummedPrice = originalPrice * Amount;
            FinalPrice = Math.Round((double)(SummedPrice - SummedPrice * Sale / 100), 2);
        }



        /// <summary>
        /// Sends the new amount of the item to the model.
        /// </summary>
        public void ChangeTheAmount()
        {
            App.Cart.ChangeAmountOfProduct(ID, Amount);
        }
    }
}
