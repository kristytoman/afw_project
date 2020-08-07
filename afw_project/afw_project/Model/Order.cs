using System;
using System.Collections.Generic;
using System.Text;

namespace afw_project
{
    class Order
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
        /// Gets or sets the order's state.
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// Gets or sets order's timestamp.
        /// </summary>
        public DateTime OrderTime { get; set; }

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
