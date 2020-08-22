using afw_project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace afw_project.View_Model.Sales
{
    class SpringPrice : Price
    {
        /// <summary>
        /// Quantity of the ordered products.
        /// </summary>
        int quantity;


        /// <summary>
        /// Creates a new instance for the spring season's prices.
        /// </summary>
        /// <param name="order">The list of product orders of the cart.</param>
        /// <param name="vM">View-model of the page.</param>
        public SpringPrice(List<ProductOrder> order, VM_Cart vM) : base(order, vM) { }



        public override ObservableCollection<CartItem> GetSale()
        {
            ElementaryPrice = 0;
            quantity = 0;

            cartItems = new ObservableCollection<CartItem>();

            foreach (ProductOrder item in order)
            {
                item.Sale = 0;
                quantity += item.Amount;

                double summedPrice = item.Product.Price * item.Amount;
                ElementaryPrice += summedPrice;

                cartItems.Add(new CartItem(viewModel, item.Product.ID, item.Product.Name, item.Amount, summedPrice));
            }

            NewPrice = ElementaryPrice;

            if (quantity > 11)
            {
                sale = 40;
                NewPrice -= Math.Round(NewPrice * 0.4, 2);
                for (int i = 0; i < cartItems.Count; i++)
                    ChangeProductPrice(i, 40);
                return cartItems;
            }
            if (quantity > 7)
            {
                sale = 30;
                NewPrice -= Math.Round(NewPrice * 0.3, 2);
                for (int i = 0; i < cartItems.Count; i++)
                    ChangeProductPrice(i, 30);
                return cartItems;
            }
            if (quantity > 2)
            {
                sale = 20;
                NewPrice -= Math.Round(NewPrice * 0.2, 2);
                for (int i = 0; i < cartItems.Count; i++)
                    ChangeProductPrice(i, 20);
            }
            return cartItems;
        }



        protected override void RecalculatePrice(int newQuantity)
        {
            quantity += newQuantity;
            if (quantity > 11)
                if (sale == 40)
                    return;
                else sale = 40;
            else if (quantity > 7)
                if (sale == 30)
                    return;
                else sale = 30;
            else if (quantity > 2)
                if (sale == 20)
                    return;
                else sale = 20;
            if (sale == 0)
                return;

            NewPrice = ElementaryPrice - Math.Round(ElementaryPrice * sale/100, 2);

            for (int i = 0; i < cartItems.Count; i++)
                ChangeProductPrice(i, sale);
        }
    }
}
