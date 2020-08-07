using System;
using System.Collections.Generic;
using System.Text;

namespace afw_project
{
    class ProductOrder
    {
        /// <summary>
        /// Gets or sets the ID of the order.
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Gets or sets the order's instance.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        ///  Gets or sets the order's instance.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the sale of the product in the current order.
        /// </summary>
        public int Sale { get; set; }

        /// <summary>
        /// Creates a new instance for the relation between product and order.
        /// </summary>
        public ProductOrder() { }
    }
}
