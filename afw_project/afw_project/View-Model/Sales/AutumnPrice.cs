using afw_project.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace afw_project.View_Model.Sales
{
    internal class AutumnPrice : Price
    {
        #region Constructor

        /// <summary>
        /// Creates a new instance for an autumn season's prices.
        /// </summary>
        /// <param name="order">The list of product orders of the cart.</param>
        /// <param name="vM">View-model of the page.</param>
        public AutumnPrice(List<ProductOrder> order, VM_Cart vM) : base(order, vM) { }

        #endregion



        #region Methods

        /// <summary>
        /// Creates a new list of ordered items for the page and their prices.
        /// </summary>
        /// <returns>Observable collection with cart items.</returns>
        public override ObservableCollection<CartItem> GetSale()
        {
            NewPrice = 0;
            ElementaryPrice = 0;
            cartItems = new ObservableCollection<CartItem>();

            foreach (ProductOrder item in order)
            {
                double summedPrice = item.Product.Price * item.Amount;

                ElementaryPrice += summedPrice;

                double newPrice = summedPrice - summedPrice * item.Product.Sale / 100;
                NewPrice += newPrice;

                cartItems.Add
                (
                    new CartItem
                    (
                        viewModel,
                        item.Product.ID,
                        item.Product.Name,
                        item.Amount,
                        summedPrice,
                        item.Product.Sale,
                        newPrice
                    )
                );
            }
            return cartItems;
        }



        protected override void RecalculatePrice(int newQuantity) { }

        #endregion
    }
}
