
using FluentValidation;

namespace BattleShip_Application.Feature
{
    public class CreateBoardCommanddValidator:AbstractValidator<CreateBoardCommand>
    {
      public CreateBoardCommanddValidator()
        {
            RuleFor(o => o.DimensionX).GreaterThan(0);
            RuleFor(o => o.DimensionY).GreaterThan(0);
        }

    }
  
}
