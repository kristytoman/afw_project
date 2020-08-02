namespace afw_project.View_Model.Validation
{
    class Description : ValidatableObject
    {
        /// <summary>
        /// Describes the type of description object for the product name.
        /// </summary>
        public const string type_productName = "name";

        /// <summary>
        /// Describes the type of description object for the product description.
        /// </summary>
        public const string type_productDescription = "description";

        /// <summary>
        /// Sets the type of description object.
        /// </summary>
        private readonly string type;

        /// <summary>
        /// Creates new validatable object to test the description input.
        /// </summary>
        /// <param name="value">Description input value.</param>
        /// <param name="type">"name" for product name or "description" for product Description</param>
        public Description(string value, string type) : base(value)
        {
            AddValidations();
            this.type = type;
        }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty() { Message = $"Please fill out the {type}" });
        }
    }
}
