using System;
using System.Text.RegularExpressions;

namespace afw_project.View_Model.Validation
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
    class IsNumber : IValidation
    {
        public string Message { get; set; }

        public bool Check(string value)
        {
            try
            {
                if (Regex.IsMatch(value, @"^[0-9 ]{2,}$"))
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
