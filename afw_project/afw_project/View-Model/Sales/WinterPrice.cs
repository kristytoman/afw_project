using afw_project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace afw_project.View_Model.Sales
{
    class WinterPrice : Price
    {
        /// <summary>
        /// Index of the most expensive product in the list of product-orders.
        /// </summary>
        private int iMostExpensive;

        /// <summary>
        /// Price of the most expensive product in the list of product-orders.
        /// </summary>
        private double highestPrice;


        /// <summary>
        /// Creates a new instance for the winter season's prices.
        /// </summary>
        /// <param name="order">The list of product orders of the cart.</param>
        /// <param name="vM">View-model of the page.</param>
        public WinterPrice(List<ProductOrder> order, VM_Cart vM) : base(order, vM)
        {
            NewPrice = 0;
            iMostExpensive = 0;
        }



        public override ObservableCollection<CartItem> GetSale()
        {
            ElementaryPrice = 0;
            highestPrice = 0;
            cartItems = new ObservableCollection<CartItem>();
            for (int i = 0; i < order.Count; i++)
            {
                double summedPrice = order[i].Product.Price * order[i].Product.Amount;
                ElementaryPrice += summedPrice;
                if (order[i].Product.Price > highestPrice)
                {
                    iMostExpensive = i;
                    highestPrice = order[i].Product.Price;
                }
                cartItems.Add(new CartItem(viewModel, order[i].Product.ID, order[i].Product.Name, order[i].Amount, summedPrice));
            }
            ChangeAmount(iMostExpensive, 30);
            NewPrice = ElementaryPrice - Math.Round(order[iMostExpensive].Product.Price * order[iMostExpensive].Product.Amount * 0.3, 2);
            return cartItems;
        }



        protected override void RecalculatePrice(int newQuantity) { }
    }
}
