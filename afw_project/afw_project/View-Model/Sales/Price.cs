using afw_project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace afw_project.View_Model.Sales
{
    abstract class Price
    {
        protected List<ProductOrder> order;
        protected ObservableCollection<CartItem> cartItems;
        protected byte sale;
        public double ElementaryPrice { get; protected set; }

        public double NewPrice { get; protected set; }

        public Price(List<ProductOrder> order)
        {
            this.order = order;
            sale = 0;
        }
        protected void ChangeProductPrice(int i, byte sale)
        {
            cartItems[i].Sale = sale;
            cartItems[i].FinalPrice = cartItems[i].SummedPrice - Math.Round(cartItems[i].SummedPrice * sale / 100, 2);
            order[i].Sale = sale;
        }
        public void ChangeProductPrice(int ID, int amount)
        {
            int index = cartItems.IndexOf(c => c.ID == ID);
            int newQuantity = amount - cartItems[index].Amount;
            cartItems[index].Amount = amount;
            order[index].Amount = amount;
            ElementaryPrice -= cartItems[index].SummedPrice;
            cartItems[index].SummedPrice = order[index].Product.Price * amount;
            ElementaryPrice += cartItems[index].SummedPrice;
            NewPrice -= cartItems[index].FinalPrice;
            cartItems[index].FinalPrice = cartItems[index].SummedPrice*cartItems[index].Sale;
            NewPrice += cartItems[index].FinalPrice;
            RecalculatePrice(newQuantity,index);
        }
        protected abstract void RecalculatePrice(int newQuantity, int index);
        public double CountThePrice()
        {
            ElementaryPrice = 0;
            foreach (ProductOrder item in order)
            {
                double summedPrice = item.Product.Price + item.Amount;
                NewPrice += summedPrice;
                cartItems.Add(new CartItem
                {
                    ID = item.Product.ID,
                    Name = item.Product.Name,
                    Amount = item.Amount,
                    SummedPrice = summedPrice,
                    FinalPrice = summedPrice
                });
            }
            return ElementaryPrice;
        }

        public abstract ObservableCollection<CartItem> GetSale();
    }
}
