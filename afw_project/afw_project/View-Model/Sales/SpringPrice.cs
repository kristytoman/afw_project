using afw_project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace afw_project.View_Model.Sales
{
    class SpringPrice : Price
    {
        int quantity;
        public SpringPrice(List<ProductOrder> order) : base(order)
        {
            
        }
        public override ObservableCollection<CartItem> GetSale()
        {
            cartItems = new ObservableCollection<CartItem>();
            ElementaryPrice = 0;
            quantity = 0;
            foreach (ProductOrder item in order)
            {
                double summedPrice = item.Product.Price * item.Amount;
                ElementaryPrice += summedPrice;
                item.Sale = 0;
                quantity += item.Amount;
                cartItems.Add
                (
                    new CartItem
                    {
                        ID = item.Product.ID,
                        Name = item.Product.Name,
                        Amount = item.Amount,
                        SummedPrice = summedPrice,
                        FinalPrice = summedPrice
                    }
                );
            }
            ElementaryPrice = Math.Round(ElementaryPrice, 2);

            NewPrice = ElementaryPrice;

            if (quantity > 11)
            {
                sale = 40;
                NewPrice -= Math.Round(NewPrice * 0.4, 2);
                for (int i = 0; i < cartItems.Count; i++)
                {
                    ChangeProductPrice(i, 40);
                }
                return cartItems;
            }
            if (quantity > 7)
            {
                sale = 30;
                NewPrice -= Math.Round(NewPrice * 0.3, 2);
                for (int i = 0; i < cartItems.Count; i++)
                {
                    ChangeProductPrice(i, 30);
                }
                return cartItems;
            }
            if (quantity > 2)
            {
                sale = 20;
                NewPrice -= Math.Round(NewPrice * 0.2, 2);
                for (int i = 0; i < cartItems.Count; i++)
                {
                    ChangeProductPrice(i, 20);
                }
            }
            return cartItems;
        }
        protected override void RecalculatePrice(int newQuantity, int index)
        {
            quantity -= newQuantity;
            if (quantity > 11)
                if (sale == 40)
                    return;
                else sale = 40;
            if (quantity > 7)
                if (sale == 30)
                    return;
                else sale = 30;
            if (quantity > 2)
                if (sale == 20)
                    return;
                else sale = 20;
            if (sale == 0)
                return;

            NewPrice -= Math.Round(NewPrice * sale/100, 2);
            for (int i = 0; i < cartItems.Count; i++)
            {
                ChangeProductPrice(i, sale);
            }
        }
    }
}
