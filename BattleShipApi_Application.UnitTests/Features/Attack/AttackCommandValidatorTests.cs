using BattleShip_Application.Feature.Attack;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleShipApi_Application.UnitTests.Features.Attack
{
    public class AttackCommandValidatorTests
    {
        private readonly AttackCommandValidator _attackCommandValidatorTest = new AttackCommandValidator();
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(null, null, null)]
        public void AttackCommand_WhenInputIsNullOrZero_ReturnsError(int boardId, int xCoordinate, int yCoordinate)
        {
            var query = new AttackCommand
            {
                AttackPositionX = xCoordinate,
                AttackPositionY = yCoordinate,
                BoardId = boardId
            };

            _attackCommandValidatorTest.ShouldHaveValidationErrorFor(x => x.BoardId, query);
            _attackCommandValidatorTest.ShouldHaveValidationErrorFor(x => x.AttackPositionX, query);
            _attackCommandValidatorTest.ShouldHaveValidationErrorFor(x => x.AttackPositionY, query);
        }
    }
}
