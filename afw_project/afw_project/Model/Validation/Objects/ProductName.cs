
namespace afw_project.Model.Validation.Objects
{
    class ProductName : ValidatableObject
    {
        public ProductName(string value) : base(value) { }



        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Name input required." });
            validations.Add(new HasRightFormat { Message = "Invalid name format.", Format = @"^[\p{L}\p{M}\d\s(),\.-'/]+$" });
            validations.Add(new HasRightStart { Message = "Invalid input beginning.", Start = @"^[\p{L}\p{M}\d\]+" });
            validations.Add(new IsShortEnough { Message = "Name input is too long.", Max = 250 });
        }
    }
}
