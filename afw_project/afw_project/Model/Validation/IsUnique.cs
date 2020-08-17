using System.Linq;

namespace afw_project.Model.Validation
{
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
