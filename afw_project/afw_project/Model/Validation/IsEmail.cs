using System;
using System.Text.RegularExpressions;

namespace afw_project.Model.Validation
{
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
}
