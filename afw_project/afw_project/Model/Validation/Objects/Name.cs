
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
            validations.Add(new IsNotEmpty { Message = "Name input required."});
            validations.Add(new HasRightFormat { Message = "Invalid name format.", Format = @"^[\p{L}\p{M}\s,\.\-']+$" });
            validations.Add(new HasRightEnding { Message = "Invalid name ending.", End = @"[^\s-]$" });
            validations.Add(new IsShortEnough { Message = "Name input is too long.", Max = 250 });
        }
    }
}
