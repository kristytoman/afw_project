
namespace afw_project.Model.Validation.Objects
{
    class Building : ValidatableObject
    {
        /// <summary>
        /// Creates new object to validate the building number. 
        /// </summary>
        /// <param name="value">Building number input.</param>
        public Building(string value) : base(value)
        {
            AddValidations();
        }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty() { Message = "Please fill in your building number" });
            validations.Add(new IsValid() { Message = "Invalid building number" });
        }
    }
}
