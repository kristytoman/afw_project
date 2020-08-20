using System;
using System.Collections.Generic;
using System.Linq;

namespace afw_project.Model
{
    public class Order
    {
        #region Database columns
        
        /// <summary>
        /// Gets or sets the ID of the order.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the order's price.
        /// </summary>
        public double Price { get; set; }

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

        #endregion


        #region Constructor

        /// <summary>
        /// Creates new order instance.
        /// </summary>
        public Order()
        {
            ProductOrders = new List<ProductOrder>();
        }

        #endregion



        #region Cart methods

        /// <summary>
        /// Adds products to the order.
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
                using (Context db = new Context())
                {
                    ProductOrders = db.ProductOrders.Where(o => o.OrderID == ID).ToList();
                    foreach (ProductOrder item in ProductOrders)
                    {
                        item.Product = db.Products.Where(p => p.ID == item.ProductID).First();
                    }
                    return ProductOrders;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// Changes the amount of the product in the order.
        /// </summary>
        /// <param name="signed"></param>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        public void ChangeAmountOfProduct(int id, int amount)
        {
            ProductOrders.First(p => p.Product.ID == id).Amount = amount;
        }

        #endregion



        #region Orders modification

        /// <summary>
        /// Creates a new instance for a cart.
        /// </summary>
        /// <returns>Initialized order.</returns>
        public static Order CreateNewCart()
        {
            return new Order
            {
                Price = 0,
                OrderTime = null,
                SendTime = null,
                ReceivedTime = null
            };
        }



        /// <summary>
        /// Sets the order as cancelled.
        /// </summary>
        /// <param name="id">ID of the order to change.</param>
        public static void CancelTheOrder(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Orders.Where(o => o.ID == id).First().SendTime=DateTime.MinValue;
                    db.SaveChanges();
                }
            }
            catch(Exception)
            {
            }
        }



        /// <summary>
        /// Sets the order as shipped.
        /// </summary>
        /// <param name="id">ID of the order to change.</param>
        public static void SendTheOrder(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    Order item = db.Orders.Where(o => o.ID == id).First();
                    item.SendTime = DateTime.Now;
                    item.ReceivedTime = null;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }



        /// <summary>
        /// Sets the order as fulfilled.
        /// </summary>
        /// <param name="id">ID of the order to change.</param>
        public static void FulfillTheOrder(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Orders.Where(o => o.ID == id).First().ReceivedTime = DateTime.Now;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }



        /// <summary>
        /// Gets all the orders from the databse.
        /// </summary>
        /// <returns>List of Orders or null.</returns>
        public static List<Order> GetAllOrders()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Orders.Where(o=>o.OrderTime!=null).ToList();
                }
            }
            catch
            {
                return null;
            }
        }



        /// <summary>
        /// Gets all the orders that haven't been shipped.
        /// </summary>
        /// <returns>List of Orders or null.</returns>
        public static List<Order> GetWaitingOrders()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Orders.Where(o => o.OrderTime!=null && o.SendTime == null && o.ReceivedTime == null).ToList();
                }
            }
            catch
            {
                return null;
            }
        }



        /// <summary>
        /// Gets all the orders that has been shipped but not received.
        /// </summary>
        /// <returns>List of Orders or null.</returns>
        public static List<Order> GetSentOrders()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Orders.Where(o => o.SendTime!=null && o.SendTime!= DateTime.MinValue && o.ReceivedTime == null).ToList();
                }
            }
            catch
            {
                return null;
            }
        }



        /// <summary>
        /// Gets all the cancelled orders.
        /// </summary>
        /// <returns>List of Orders or null.</returns>
        public static List<Order> GetCancelledOrders()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Orders.Where(o => o.SendTime == DateTime.MinValue).ToList();
                }
            }
            catch
            {
                return null;
            }
        }



        /// <summary>
        /// Gets all the finished orders.
        /// </summary>
        /// <returns>List of orders or null.</returns>
        public static List<Order> GetFulfilledOrders()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Orders.Where(o => o.SendTime != null && o.SendTime != DateTime.MinValue && o.ReceivedTime!=null).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
