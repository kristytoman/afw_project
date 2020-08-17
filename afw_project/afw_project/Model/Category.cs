using afw_project.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace afw_project.Model
{
    public class Category
    {
        #region Database columns
        /// <summary>
        /// Gets or sets the ID of the category.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of products connected to the category.
        /// </summary>
        public List<Product> Products { get; set; }
        #endregion


        #region Constructors
        /// <summary>
        /// Creates new instance for a category.
        /// </summary>
        public Category()
        {
            Products = new List<Product>();
        }


        /// <summary>
        /// Creates new instance for the category.
        /// </summary>
        /// <param name="name">Name of the category.</param>
        public Category(string name)
        {
            Name = name;
            using (Context db = new Context())
            {
                try
                {
                    ID = db.Categories.Where(x => x.Name == name).First().ID;
                }
                catch (Exception)
                {

                }
                finally
                {
                    Products = new List<Product>();
                }
            }
        }
        #endregion



        #region Get methods
        /// <summary>
        /// Gets all categories in the database.
        /// </summary>
        /// <returns>List of Categories object or null if there's a mistake</returns>
        public static List<Category> GetCategories()
        {
            using (Context db = new Context())
            {
                try
                {
                    return db.Categories.ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets products from the category.
        /// </summary>
        /// <returns>List of products or null if a mistake occured.</returns>
        public List<ProductItem> GetProducts()
        {
            try
            {
                using (Context db = new Context())
                {
                    List<ProductItem> results = new List<ProductItem>();
                    foreach (Product p in db.Products.Where(p => p.Category.Name == Name && p.Amount>=0).ToList())
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
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
