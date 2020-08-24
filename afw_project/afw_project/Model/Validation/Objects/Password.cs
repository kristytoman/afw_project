
namespace afw_project.Model.Validation.Objects
{
    class Password : ValidatableObject
    {
        private readonly bool required;
        /// <summary>
        /// Creates new validatable object to test the password input.
        /// </summary>
        /// <param name="value">Password input value.</param>
        public Password(string value, bool required) : base(value) 
        {
            this.required = required;
        }

        protected override void AddValidations()
        {
            if (required)
            {
                validations.Add(new IsNotEmpty() { Message = "Password is required." });
            }
            validations.Add(new IsValidPassword() { Message = "Invalid password." });
        }
    }
}
