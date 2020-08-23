
namespace afw_project.Model.Validation.Objects
{
    class Description : ValidatableObject
    {

        /// <summary>
        /// Creates new validatable object to test the description input.
        /// </summary>
        /// <param name="value">Description input value.</param>
        /// <param name="type">"name" for product name or "description" for product Description</param>
        public Description(string value) : base(value) { }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty() { Message = $"Please fill in the description." });
        }
    }
}
