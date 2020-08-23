
namespace afw_project.Model.Validation.Objects
{
    class Email : ValidatableObject
    {
        /// <summary>
        /// Object for validating e-mail input.
        /// </summary>
        /// <param name="value">E-mail input value.</param>
        public Email(string value) : base(value) { }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty() { Message = "Email address is required." });
            validations.Add(new IsEmail() { Message = "Not supported email address" });
            validations.Add(new IsUnique() { Message = "Email address already exists in our eshop" });
        }
    }
}
