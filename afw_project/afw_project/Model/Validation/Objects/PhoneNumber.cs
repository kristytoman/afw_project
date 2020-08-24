
namespace afw_project.Model.Validation.Objects
{
    class PhoneNumber : ValidatableObject
    {
        /// <summary>
        /// Creates new validatable object to test the phone number input.
        /// </summary>
        /// <param name="value">Phone number input value.</param>
        public PhoneNumber(string value) : base(value) { }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Phone number is required." });
            validations.Add(new HasRightFormat { Message = "Invalid phone number format.", Format=@"^[\d\+]+$" });
            validations.Add(new HasRightStart { Message = "Invalid input beginning.", Start = @"^\+\d+" });
            validations.Add(new HasRightEnding { Message = "Invalid input ending.", End = @"\d+$" });
            validations.Add(new IsLongEnough { Message = "Input is too short.", Min = 7 });
            validations.Add(new IsShortEnough { Message = "Input is too long.", Max = 18 });
        }
    }
}
