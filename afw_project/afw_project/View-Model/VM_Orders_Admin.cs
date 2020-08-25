using afw_project.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace afw_project.View_Model
{
    class VM_Orders_Admin : VM_Base
    {
        /// <summary>
        /// Gets or sets the list of orders.
        /// </summary>
        public ObservableCollection<OrderItem> List_Orders { get; set; }


        /// <summary>
        /// Creates the view model for orders for admin.
        /// </summary>
        /// <param name="name">Title of the page.</param>
        public VM_Orders_Admin(string name)
        {
            List<Order> result;
            List_Orders = new ObservableCollection<OrderItem>();
            switch (name)
            {
                case "All":
                    result = Order.GetAllOrders();
                    break;
                case "Waiting":
                    result = Order.GetWaitingOrders();
                    break;
                case "Sent":
                    result = Order.GetSentOrders();
                    break;
                case "Fulfilled":
                    result = Order.GetFulfilledOrders();
                    break;
                case "Cancelled":
                    result = Order.GetCancelledOrders();
                    break;
                default:
                    result = null;
                    break;
            }
            if (result != null)
            {
                foreach (Order item in result)
                {
                    OrderItem oi = new OrderItem(item, true);
                    foreach (ProductOrder product in item.GetOrderProducts())
                    {
                        oi.Add
                        (
                            new Order_ProductItem
                            (
                                product.Product.Name,
                                product.Amount.ToString() + " pcs",
                                product.Product.Price.ToString() + " EUR",
                                product.Sale.ToString() + " %",
                                ((product.Product.Price - product.Product.Price * product.Sale) * product.Amount).ToString() + " EUR"
                            )
                        );
                    }
                    List_Orders.Add(oi);
                }
            }
        }
    }
}
