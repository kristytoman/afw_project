
namespace afw_project.Model.Validation.Objects
{
    class Name : ValidatableObject
    {

        /// <summary>
        /// Creates new validatable object to test the name input.
        /// </summary>
        /// <param name="value">Name input value.</param>
        /// <param name="type">Described with consts in the Name class.</param>
        public Name(string value) : base(value) { }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty() { Message = $"Please fill your first name."});
            validations.Add(new IsSupported() { Message = $"Not suported format for first name." });
        }
    }
}
