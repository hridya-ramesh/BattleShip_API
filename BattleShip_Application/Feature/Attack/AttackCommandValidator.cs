using FluentValidation;

namespace BattleShip_Application.Feature.Attack
{
    public class AttackCommandValidator : AbstractValidator<AttackCommand>
    {
        public AttackCommandValidator()
        {
            RuleFor(o => o.AttackPositionX).GreaterThan(0);
            RuleFor(o => o.AttackPositionY).GreaterThan(0);
            RuleFor(o => o.BoardId).GreaterThan(0);
        }
    }
}
