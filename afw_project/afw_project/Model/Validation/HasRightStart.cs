using System;
using System.Text.RegularExpressions;

namespace afw_project.Model.Validation
{
    class HasRightStart : IValidation
    {
        public string Message { get; set; }

        public string Start { get; set; }

        public bool Check(string value)
        {
            try
            {
                if (Regex.IsMatch(value, Start))
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
