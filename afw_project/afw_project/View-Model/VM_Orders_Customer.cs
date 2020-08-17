using System.Collections.Generic;

namespace afw_project.View_Model
{
    class VM_Orders_Customer : VM_Base
    {
        public List<OrderItem> Orders { get; private set; }
        public VM_Orders_Customer()
        {
            List<Order> result = App.User.GetOrders();
            Orders = new List<OrderItem>();
            if (result != null)
            {
                foreach (Order item in result)
                {
                    OrderItem oi = new OrderItem(item, false);
                    List<ProductOrder> products_list = item.GetOrderProducts();
                    for (int i = 0; i < products_list.Count; i++)
                    {
                        var product = products_list[i];
                        oi.Add
                        (
                            new Order_ProductItem
                            (
                                name: product.Product.Name,
                                amount: product.Amount.ToString() + " pcs",
                                originalPrice: product.Product.Price.ToString() + " EUR",
                                sale: product.Sale.ToString() + " %",
                                finalPrice: ((product.Product.Price - product.Product.Price * product.Sale) * product.Amount).ToString() + " EUR"
                            )
                        );
                    }
                    Orders.Add(oi);
                }
            }
        }
    }
}
