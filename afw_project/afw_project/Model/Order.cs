using System;
using System.Collections.Generic;
namespace afw_project
{
    public class Order
    {
        /// <summary>
        /// Gets or sets the ID of the order.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the order's price.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the time of ordering.
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// Gets or sets the time of sending the order.
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// Gets or sets the time of receiving the order.
        /// </summary>
        public DateTime ReceivedTime { get; set; }

        /// <summary>
        /// Gets or sets order's owner.
        /// </summary>
        public Customer Customer { get; set; }

        // Gets or sets the ordered products.
        public IList<ProductOrder> ProductOrders { get; set; }

        /// <summary>
        /// Creates new order instance.
        /// </summary>
        public Order() { }
    }
}
