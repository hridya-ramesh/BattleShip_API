using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip_Application.Feature
{
    public class AddShipCommandValidator : AbstractValidator<AddShipCommand>
    {
        public AddShipCommandValidator()
        {
            RuleFor(o => o.ShipPositionX).GreaterThan(0);
            RuleFor(o => o.ShipPositionY).GreaterThan(0);
            RuleFor(o => o.BoardId).GreaterThan(0);
        }
    }
}
