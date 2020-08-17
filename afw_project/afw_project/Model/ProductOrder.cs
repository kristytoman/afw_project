namespace afw_project.Model
{
    public class ProductOrder
    {
        #region Database columns
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
        /// Gets or sets the amount of the ordered product.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        ///  Gets or sets the order's instance.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the sale of the product in the current order.
        /// </summary>
        public int Sale { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Database constructor
        /// </summary>
        public ProductOrder(){ }
        #endregion
    }
}
