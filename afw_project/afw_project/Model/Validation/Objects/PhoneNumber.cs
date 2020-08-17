
namespace afw_project.Model.Validation.Objects
{
    class PhoneNumber : ValidatableObject
    {
        /// <summary>
        /// Creates new validatable object to test the phone number input.
        /// </summary>
        /// <param name="value">Phone number input value.</param>
        public PhoneNumber(string value) : base(value)
        {
            AddValidations();
        }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty() { Message = "Phone number is required." });
            validations.Add(new IsPhoneNumber() { Message = "The phone number format is +XXXXXXXXXXXX" });
        }
    }
}
