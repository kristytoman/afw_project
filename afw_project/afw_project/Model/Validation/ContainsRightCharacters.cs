using System;
using System.Linq;

namespace afw_project.Model.Validation
{
    class ContainsRightCharacters : IValidation
    {
        public string Message { get; set; }

        /// <summary>
        /// Allowed characters.
        /// </summary>
        public string Characters { get; set; }

        public bool Check(string value)
        {
            foreach (char ch in value.ToArray())
            {
                if (!Characters.Contains(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
