using afw_project.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace afw_project
{
    public class Product
    {
        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the product's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product's price.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the product's sale.
        /// </summary>
        public int Sale { get; set; }

        /// <summary>
        /// Gets or sets the number of products.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the product's description.
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Gets or sets the product's category.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Gets or sets the product's orders.
        /// </summary>
        public List<ProductOrder> ProductOrders { get; set; }

        /// <summary>
        /// Creates a product's instance.
        /// </summary>
        public Product()
        {

        }

        /// <summary>
        /// Creates a new product's instance for the admin.
        /// </summary>
        /// <param name="name">Product's name input.</param>
        /// <param name="categoryName">Product's category input.</param>
        /// <param name="description">Product's description input.</param>
        /// <param name="price">Product's price input.</param>
        /// <param name="amount">Product's amount input.</param>
        public Product(string name, string categoryName, string description, int price, int amount)
        {
            Name = name;
            Description = description;
            Price = price;
            Amount = amount;
            Context db = new Context();
            try
            {
                Category = db.Categories.Where(c => c.Name == categoryName).First();
            }
            catch
            {
                try
                {
                    Category = db.Categories.Add(new Category(categoryName)).Entity;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
            }
        }

        public static bool ChangeProduct(int id, string name, string categoryName, string description, int price, int amount)
        {
            try
            {
                using (Context db = new Context())
                {
                    Product product = db.Products.First(p => p.ID == id);
                    product.Name = name;
                    product.Description = description;
                    product.Price = price;
                    product.Amount = amount;
                    product.Category = new Category(categoryName);
                    db.Attach(product.Category);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Entries the product into the database.
        /// </summary>
        /// <returns>True if successful, false if any mistake occured.</returns>
        public bool CreateNewProduct()
        {
            if (Category == null)
            {
                return false;
            }
            Context db = new Context();
            try
            {
                db.Attach(Category);
                Category.Products.Add(this);

                if (db.SaveChanges() == 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Gets all products from the database.
        /// </summary>
        /// <returns>List of products or null.</returns>
        public static List<ProductView> GetAll()
        {
            try
            {
                using (Context db = new Context())
                {
                    List<ProductView> results = new List<ProductView>();
                    foreach (Product p in db.Products.Where(p=>p.Amount>=0).ToList())
                    {
                        results.Add(new ProductView(p));
                    }
                    if (results.Count == 0)
                    {
                        return null;
                    }
                    else return results;
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool DeleteProduct(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    Product product = db.Products.First(p => p.ID == id);
                    product.Amount = -1;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
