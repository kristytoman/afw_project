
namespace afw_project.Model.Validation.Objects
{
    class CityName : ValidatableObject
    {
        public CityName(string value) : base(value) { }



        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "City name required." });
            validations.Add(new HasRightFormat { Message = "Invalid format.", Format = @"^[\p{L}\p{M}\s,\.\-0-9']+$"});
            validations.Add(new IsShortEnough { Message = "City input is too long.", Max = 250 });
        }
    }
}
