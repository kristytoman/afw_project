using System;
using System.Text.RegularExpressions;

namespace afw_project.Validation
{
    class Name : ValidatableObject
    {
        /// <summary>
        /// Describes the type of name object for the customer's first name.
        /// </summary>
        public const string type_firstName = "first name";

        /// <summary>
        /// Describes the type of name object for the customer's last name.
        /// </summary>
        public const string type_lastName = "last name";

        /// <summary>
        /// Describes the type of name object for the customer's street name.
        /// </summary>
        public const string type_street = "street name";

        /// <summary>
        /// Describes the type of name object for the customer's city name.
        /// </summary>
        public const string type_city = "city name";

        /// <summary>
        /// Sets the type of name object.
        /// </summary>
        private string type;

        /// <summary>
        /// Creates new validatable object to test the name input.
        /// </summary>
        /// <param name="value">Name input value.</param>
        /// <param name="type">Described with consts in the Name class.</param>
        public Name(string value, string type) : base(value)
        {
            this.type = type;
            AddValidations();
        }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty() { Message = $"Please fill your {type}"});
            validations.Add(new IsSupported() { Message = $"Not suported format for {type}" });
        }

        
    }
    class IsSupported : IValidation
    {
        public string Message { get; set; }

        public bool Check(string value)
        {
            try
            {
                if (Regex.IsMatch(value, @"[\p{L}\p{M}- ]{2,}"))
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
