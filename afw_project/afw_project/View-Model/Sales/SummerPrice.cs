using afw_project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace afw_project.View_Model.Sales
{
    internal class SummerPrice : Price
    {
        public SummerPrice(List<ProductOrder> order) : base(order)
        {

        }

        public override ObservableCollection<CartItem> GetSale()
        {
            cartItems = new ObservableCollection<CartItem>();
            ElementaryPrice = CountThePrice();
            if (App.User.Password == null || App.User.Password == string.Empty)
            {
                return cartItems;
            }

            int quantity = App.User.Orders.Count;
            NewPrice = ElementaryPrice;

            if (quantity > 9)
            {
                sale = 20;
                NewPrice -= Math.Round(NewPrice * 0.2);
                for (int i = 0; i < order.Count; i++)
                {
                    ChangeProductPrice(i, 20);
                }
                return cartItems;
            }
            if (quantity > 4)
            {
                sale = 10;
                NewPrice -= Math.Round(NewPrice * 0.1);
                for (int i = 0; i < order.Count; i++)
                {
                    ChangeProductPrice(i, 10);
                }
            }
            return cartItems;
        }

        protected override void RecalculatePrice(int newQuantity,int index)
        {
        }
    }
}
