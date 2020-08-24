
namespace afw_project.Model.Validation.Objects
{
    class CategoryName : ValidatableObject
    {
        public CategoryName(string value) : base(value) { }



        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Category name required." });
            validations.Add(new HasRightFormat { Message = "Invalid format.", Format = @"^(?=.*\p{L}\p{M})[\p{L}\p{M}\d\s(),\.-'/]+$" });
            validations.Add(new HasRightEnding { Message = "Invalid ending characters", End = @"[^\w-/,(]$" });
            validations.Add(new IsLongEnough { Message = "Input is too short.", Min = 2 });
            validations.Add(new IsShortEnough { Message = "Input is too long.", Max = 250 });
        }
    }
}
