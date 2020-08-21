using afw_project.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace afw_project.Model
{
    public class Product
    {
        #region Database columns
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
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the product's sale.
        /// </summary>
        public byte Sale { get; set; }

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
        #endregion


        #region Constructors
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
        /// Database constructor.
        /// </summary>
        public Product() { }
        #endregion



        #region Product modification
        /// <summary>
        /// Entries the product into the database.
        /// </summary>
        /// <returns>True if successful, false if any mistake occured.</returns>
        public bool CreateNewProduct()
        {
            if (Category != null)
            {
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
            return false;
        }



        /// <summary>
        /// Changes the product information.
        /// </summary>
        /// <param name="id">Identification number of the product.</param>
        /// <param name="name">Name of the product.</param>
        /// <param name="categoryName">Name of the product's category.</param>
        /// <param name="description">Product's description.</param>
        /// <param name="price">Price of the product.</param>
        /// <param name="amount">Amount of the product.</param>
        /// <returns>True if succesfull, false if not.</returns>
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
        /// Marks the product as deleted.
        /// </summary>
        /// <param name="id">Identification number of the product.</param>
        /// <returns></returns>
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



        /// <summary>
        /// Sets the sale of products to zero.
        /// </summary>
        public static void ResetSale()
        {
            try
            {
                using (Context db = new Context())
                {
                    foreach (Product product in db.Products.Where(p => p.Sale != 0).ToList())
                    {
                        product.Sale = 0;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception) { }
        }
        


        /// <summary>
        /// Sets the sale of the product.
        /// </summary>
        /// <param name="ID">ID of the product.</param>
        /// <param name="sale">Sale of the product.</param>
        public static void SetSale(int ID, byte sale)
        {
            try
            {
                using(Context db = new Context())
                {
                    db.Products.Where(p => p.ID == ID).First().Sale = sale;
                    db.SaveChanges();
                }
            }
            catch (Exception) { }
        }
        
        #endregion



        #region  Products view
        /// <summary>
        /// Gets all products from the database.
        /// </summary>
        /// <returns>List of products or null.</returns>
        public static List<ProductItem> GetAll()
        {
            try
            {
                using (Context db = new Context())
                {
                    List<ProductItem> results = new List<ProductItem>();
                    foreach (Product p in db.Products.Where(p=>p.Amount>=0).ToList())
                    {
                        results.Add(new ProductItem(p));
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

        /// <summary>
        /// Gets a product by ID.
        /// </summary>
        /// <param name="id">Identification number of the product.</param>
        /// <returns>Product instance or null.</returns>
        public static Product GetProduct(int id)
        {
            try
            {
                using(Context db = new Context())
                {
                    return db.Products.First(p => p.ID == id);
                }
            }
            catch(Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
