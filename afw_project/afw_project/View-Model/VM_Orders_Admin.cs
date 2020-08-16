using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace afw_project.View_Model
{
    class VM_Orders_Admin : VM_Base
    {
        public List<OrderItem> Orders { get; set; }

        public VM_Orders_Admin(string name)
        {
            List<Order> result;
            Orders = new List<OrderItem>();
            switch(name)
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
                    OrderItem oi = new OrderItem(item);
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
                    Orders.Add(oi);
                }
            }
        }
    }
}
