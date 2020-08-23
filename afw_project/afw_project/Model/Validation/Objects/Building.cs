
namespace afw_project.Model.Validation.Objects
{
    class Building : ValidatableObject
    {
        /// <summary>
        /// Creates new object to validate the building number. 
        /// </summary>
        /// <param name="value">Building number input.</param>
        public Building(string value) : base(value) { }



        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty{ Message = "Building number required." });
            validations.Add(new HasRightFormat { Message = "Invalid building number format.", Format = "[0-9a-zA-Z -/]*" });
            validations.Add(new HasRightStart { Message = "Building number starts with number.", Start = @"^[0-9]" });
            validations.Add(new HasRightEnding { Message = "Building number ends with no special symbol.", End = @"[0-9a-zA-Z]$" });
            validations.Add(new IsShortEnough { Message = "Input is too long.", Max = 10 });
        }
    }
}
