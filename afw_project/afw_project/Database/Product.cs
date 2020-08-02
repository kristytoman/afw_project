using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace afw_project
{
    class Product
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
        /// <returns></returns>
        public static List<Product> GetAll()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Products.ToList();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
