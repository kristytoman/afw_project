using System;
using System.Text.RegularExpressions;

namespace afw_project.Validation
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

    public class IsPhoneNumber : IValidation
    {
        public string Message { get; set; }

        public bool Check(string value)
        {
            try
            {
                if (Regex.IsMatch(value, @"^\+[0-9]{7,15}$")) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
