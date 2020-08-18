using afw_project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace afw_project.View_Model.Sales
{
    internal class AutumnPrice : Price
    {
        public AutumnPrice(List<ProductOrder> order) : base(order)
        {

        }

        public override ObservableCollection<CartItem> GetSale()
        {
            cartItems = new ObservableCollection<CartItem>();
            NewPrice = 0;
            ElementaryPrice = 0;
            foreach (ProductOrder item in order)
            {
                double summedPrice = item.Product.Price * item.Amount;
                ElementaryPrice += summedPrice;
                double newPrice = GetProductPrice(item.Product.Price * item.Amount, item.Product.Sale);
                cartItems.Add(new CartItem
                {
                    ID = item.Product.ID,
                    Name = item.Product.Name,
                    Amount = item.Amount,
                    Sale = item.Product.Sale,
                    SummedPrice = summedPrice,
                    FinalPrice = newPrice
                });
                NewPrice += newPrice;
            }
            return cartItems;
        }

        private static double GetProductPrice(double elementaryPrice, byte sale)
        {
            if (sale == 0) return elementaryPrice;
            return elementaryPrice - Math.Round(elementaryPrice / 100 * sale);
        }

        protected override void RecalculatePrice(int newQuantity,int index)
        {
        }
    }
}
