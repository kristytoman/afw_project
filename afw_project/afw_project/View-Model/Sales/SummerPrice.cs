using afw_project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace afw_project.View_Model.Sales
{
    internal class SummerPrice : Price
    {
        /// <summary>
        /// Creates a new instance for the summer season's prices.
        /// </summary>
        /// <param name="order">The list of product orders of the cart.</param>
        /// <param name="vM">View-model of the page.</param>
        public SummerPrice(List<ProductOrder> order,VM_Cart vM) : base(order,vM) { }


        public override ObservableCollection<CartItem> GetSale()
        {
            cartItems = new ObservableCollection<CartItem>();
          
            ElementaryPrice = CountThePrice();
            NewPrice = ElementaryPrice;

            
            if (App.User.Password == null || App.User.Password == string.Empty)
            {
                return cartItems;
            }

            int quantity = App.User.Orders.Count;

            if (quantity > 9)
            {
                sale = 20;
                NewPrice -= Math.Round(NewPrice * 0.2);
                for (int i = 0; i < order.Count; i++)
                    ChangeProductPrice(i, (byte)20);
                return cartItems;
            }
            if (quantity > 4)
            {
                sale = 10;
                NewPrice -= Math.Round(NewPrice * 0.1);
                for (int i = 0; i < order.Count; i++)
                    ChangeProductPrice(i, (byte)10);
            }
            return cartItems;
        }



        protected override void RecalculatePrice(int newQuantity) { }
    }
}
