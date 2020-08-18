using afw_project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace afw_project.View_Model.Sales
{
    class WinterPrice : Price
    {
        private int iMostExpensive;
        private double highestPrice;
        public WinterPrice(List<ProductOrder> order) : base(order)
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
                cartItems.Add
                (
                    new CartItem
                    {
                        ID = order[i].Product.ID,
                        Name = order[i].Product.Name,
                        Amount = order[i].Amount,
                        SummedPrice = summedPrice,
                        FinalPrice = summedPrice
                    }
                );
            }
            ChangeProductPrice(iMostExpensive, 30);
            NewPrice = ElementaryPrice - Math.Round(order[iMostExpensive].Product.Price * order[iMostExpensive].Product.Amount * 0.3, 2);
            return cartItems;
        }

        protected override void RecalculatePrice(int newQuantity, int index)
        {
            if (order[index].Product.Price > highestPrice)
            {
                iMostExpensive = index;
                highestPrice = order[index].Product.Price;
                ChangeProductPrice(index, 30);
                NewPrice = ElementaryPrice - Math.Round(order[iMostExpensive].Product.Price * order[iMostExpensive].Product.Amount * 0.3, 2);
            }
        }
    }
}
