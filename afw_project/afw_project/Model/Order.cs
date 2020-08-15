using afw_project.View_Model;
using Microsoft.EntityFrameworkCore;
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
        public DateTime? OrderTime { get; set; }

        /// <summary>
        /// Gets or sets the time of sending the order.
        /// </summary>
        public DateTime? SendTime { get; set; }

        /// <summary>
        /// Gets or sets the time of receiving the order.
        /// </summary>
        public DateTime? ReceivedTime { get; set; }

        /// <summary>
        /// Gets or sets order's owner.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the ordered products.
        /// </summary>
        public List<ProductOrder> ProductOrders { get; set; }


        /// <summary>
        /// Creates new order instance.
        /// </summary>
        public Order() 
        {
            ProductOrders = new List<ProductOrder>();
        }



        /// <summary>
        /// Add products to the order.
        /// </summary>
        /// <param name="id">ID of the selected product.</param>
        /// <returns>True if successful, False if an error occured.</returns>
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
            catch (Exception)
            {
                return false;

            }
        }



        /// <summary>
        /// Returns the ordered products list.
        /// </summary>
        /// <returns></returns>
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


        //update this method
        /// <summary>
        /// Changes the amount of the product in the order.
        /// </summary>
        /// <param name="signed"></param>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        public void ChangeAmountOfProduct(bool signed, int id, int amount)
        {
            ProductOrders.First(p => p.Product.ID == id).Amount = amount;
        }

        /// <summary>
        /// Saves the order in the database
        /// </summary>
        public void SendTheOrder()
        {
            OrderTime = DateTime.Now;
            SendTime = null;
            ReceivedTime = null;
            Price = 0;
            using (Context db = new Context())
            {
                db.Attach(Customer);
                foreach (ProductOrder item in ProductOrders)
                {
                    Price += (item.Product.Price - item.Sale * item.Product.Price) * item.Amount;
                    item.Order = this;
                    item.ProductID = item.Product.ID;
                    db.ProductOrders.Add(item);
                    db.Products.Attach(item.Product);
                }
                db.Orders.Add(this);

                db.SaveChanges();
            }
        }
    }
}
