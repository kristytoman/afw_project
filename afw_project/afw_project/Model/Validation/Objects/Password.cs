
namespace afw_project.Model.Validation.Objects
{
    class Password : ValidatableObject
    {
        /// <summary>
        /// Creates new validatable object to test the password input.
        /// </summary>
        /// <param name="value">Password input value.</param>
        public Password(string value) : base(value)
        {
            AddValidations();
        }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty() { Message = "Password is required" });
            validations.Add(new IsValidPassword() { Message = "Invalid password" });
        }
    }
}
