
namespace afw_project.Model.Validation.Objects
{
    class Number : ValidatableObject
    {
        /// <summary>
        /// Creates new validatable object to test the number input.
        /// </summary>
        /// <param name="value">Number input value.</param>
        public Number(string value) : base(value)
        {
            AddValidations();
        }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty() { Message = "Postal code is required." });
            validations.Add(new IsNumber() { Message = "Invalid Postal code format" });
        }
    }
}
