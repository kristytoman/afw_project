
namespace afw_project.Model.Validation
{
    interface IValidation
    {
        /// <summary>
        /// Error message to display
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Test the rule
        /// </summary>
        /// <param name="value">Input to validate</param>
        /// <returns></returns>
        bool Check(string value);
    }
}
