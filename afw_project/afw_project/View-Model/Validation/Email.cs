using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace afw_project.Validation
{
    class Email : ValidatableObject
    {
        /// <summary>
        /// Object for validating e-mail input.
        /// </summary>
        /// <param name="value">E-mail input value.</param>
        public Email(string value) : base(value)
        {
            AddValidations();
        }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty() { Message = "Email address is required." });
            validations.Add(new IsEmail() { Message = "Not supported email address" });
            validations.Add(new IsUnique() { Message = "Email address already exists in our eshop" });
        }

    }

    class IsEmail : IValidation
    {
        public string Message { get; set; }

        /// <summary>
        /// Checks the right formating of the email by regex.
        /// </summary>
        /// <param name="value">Input value to check.</param>
        /// <returns>True if the value is supported by the formating, false if it doesn't correspond the formating.</returns>
        public bool Check(string value)
        {
            try
            {
                if (Regex.IsMatch(value,@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"))
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    class IsUnique : IValidation
    {
        public string Message { get; set; }

        /// <summary>
        /// Checks in the database whether there is another user with the same email.
        /// </summary>
        /// <param name="value">Input value of the e-mail to check.</param>
        /// <returns>True if the value is unique, false if it already exists in the database.</returns>
        public bool Check(string value)
        {
            Context db = new Context();
            try
            {
                var mail = db.Customers.Where(c => c.Email == value).Single();
            }
            catch
            {
                return true;
            }
            return false;
        }
    }
}
