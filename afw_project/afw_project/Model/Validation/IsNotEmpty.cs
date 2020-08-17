
namespace afw_project.Model.Validation
{
    public class IsNotEmpty : IValidation
    {
        public string Message { get; set; }
        public bool Check(string value)
        {
            if (value == null)
            {
                return false;
            }
            if (value == string.Empty)
            {
                return false;
            }
            return true;
        }
    }
}
