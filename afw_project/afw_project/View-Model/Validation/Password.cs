using System;
using System.Text.RegularExpressions;

namespace afw_project
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

    class IsValidPassword : IValidation
    {
        public string Message { get; set; }

        public bool Check(string value)
        {
            try
            {
                if (Regex.IsMatch(value, @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[\]:;<>,.?/~_+-=|\\]).{8,}$"))
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
