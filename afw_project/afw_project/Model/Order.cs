using afw_project.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

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
        public List<ProductOrder> ProductOrders { get; set; }

        /// <summary>
        /// Creates new order instance.
        /// </summary>
        public Order() 
        {
            ProductOrders = new List<ProductOrder>();
        }

        public bool AddProduct(int id)
        {
            try
            {
                if (ProductOrders.Where(p => p.Product.ID == id).Count() == 1)
                {
                    ProductOrders.First(p => p.Product.ID == id).Amount++;
                    return true;
                    
                }
                else if (ProductOrders.Where(p => p.Product.ID == id).Count() == 0)
                {
                    Product product = Product.GetProduct(id);
                    ProductOrders.Add(new ProductOrder { Product = product, Order = this, Amount = 1, Sale = product.Sale });
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                    return false;
                
            }
        }

        public List<ProductOrder> GetOrderProducts()
        {
            try
            {
                return ProductOrders;

            }
            catch (Exception)
            {
                return null;
            }
        }
        public void ChangeAmountOfProduct(bool signed, int id, int amount)
        {
            ProductOrders.First(p => p.Product.ID == id).Amount = amount;
        }
    }
}
