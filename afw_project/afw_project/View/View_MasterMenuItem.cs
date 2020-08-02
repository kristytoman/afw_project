using System;
namespace afw_project.View.Admin
{ 
    public class View_MasterMenuItem
    {
        /// <summary>
        /// Creates new list view item for page navigation.
        /// </summary>
        public View_MasterMenuItem() { }


        /// <summary>
        /// Gets or sets the ID of the menu item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title name of the item and future page.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the type of the future page.
        /// </summary>
        public Type TargetType { get; set; }

    }
}