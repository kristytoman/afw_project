using afw_project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace afw_project.View_Model.Sales
{
    abstract class Price
    {
        #region Fields and properties
        /// <summary>
        /// List of cart's product-orders.
        /// </summary>
        protected List<ProductOrder> order;

        /// <summary>
        /// List of viewed items.
        /// </summary>
        protected ObservableCollection<CartItem> cartItems;

        /// <summary>
        /// Sale of the order.
        /// </summary>
        protected byte sale;

        /// <summary>
        /// View-model of the cart page.
        /// </summary>
        protected VM_Cart viewModel;

        /// <summary>
        /// Total cost of the order without sales.
        /// </summary>
        public double ElementaryPrice { get; protected set; }

        /// <summary>
        /// Total cost of the order with sales.
        /// </summary>
        public double NewPrice { get; protected set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Creates a new instance for a sale season.
        /// </summary>
        /// <param name="order">List of product-orders of the cart.</param>
        /// <param name="viewModel">View-model of the page.</param>
        public Price(List<ProductOrder> order,VM_Cart viewModel)
        {
            this.order = order;
            this.viewModel = viewModel;
            sale = 0;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Adds a sale to the product.
        /// </summary>
        /// <param name="i">Index in the list of product-orders/cart items.</param>
        /// <param name="sale">Sale of the product.</param>
        protected void ChangeProductPrice(int i, byte sale)
        {
            cartItems[i].Sale = sale;
            cartItems[i].FinalPrice = cartItems[i].SummedPrice - Math.Round(cartItems[i].SummedPrice * sale / 100, 2);

            order[i].Sale = sale;
        }



        /// <summary>
        /// Changes the quantity of the ordered product.
        /// </summary>
        /// <param name="ID">ID of the product.</param>
        /// <param name="amount">Neq quantity of the product.</param>
        public void ChangeAmount(int ID, int amount)
        {
            int index = cartItems.IndexOf(c => c.ID == ID);

            int newQuantity = amount - cartItems[index].Amount; /// The difference between the new and old quantity.
            cartItems[index].Amount = amount;
            order[index].Amount = amount;

            /// Changes the Elementary total cost.
            ElementaryPrice -= cartItems[index].SummedPrice; 
            cartItems[index].SummedPrice = order[index].Product.Price * amount;
            ElementaryPrice += cartItems[index].SummedPrice;

            /// Changes the final total cost.
            NewPrice -= cartItems[index].FinalPrice;
            cartItems[index].FinalPrice = cartItems[index].SummedPrice * cartItems[index].Sale;
            NewPrice += cartItems[index].FinalPrice;

            /// Recalculates the prices for the spring sale dependent on the amount.
            RecalculatePrice(newQuantity);
        }



        /// <summary>
        /// Sums the price of all products and adds them to the list.
        /// </summary>
        /// <returns>The summed price of the products.</returns>
        public double CountThePrice()
        {
            ElementaryPrice = 0;
            foreach (ProductOrder item in order)
            {
                double summedPrice = item.Product.Price * item.Amount;
                ElementaryPrice += summedPrice;
                cartItems.Add(new CartItem(viewModel,item.Product.ID,item.Product.Name,item.Amount,summedPrice));
            }
            return ElementaryPrice;
        }



       /// <summary>
       /// Initializes the cart list and it's prices regarding to the season sale.
       /// </summary>
       /// <returns>The observable collection of the items to show.</returns>
        public abstract ObservableCollection<CartItem> GetSale();



        /// <summary>
        /// Recalculates the prices for the spring sale dependent on the amount.
        /// Really inefective solution for the requirement of using the abstract method.
        /// </summary>
        /// <param name="newQuantity">The difference between old and new quantity of the ordered product.</param>
        protected abstract void RecalculatePrice(int newQuantity);

        #endregion
    }
}
