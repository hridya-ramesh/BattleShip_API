using BattleShip_Application.Feature;
using FluentValidation.TestHelper;
using Xunit;

namespace BattleShipApi_Application.UnitTests.Features.Ship
{
    public class AddShipCommandValidatorTests
    {
        private readonly AddShipCommandValidator _addShipCommandValidatorTest = new AddShipCommandValidator();
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(null, null, null)]
        public void AddShipCommand_WhenInputIsNullOrZero_ReturnsError(int boardId, int xCoordinate, int yCoordinate)
        {
            var query = new AddShipCommand
            {
                ShipPositionX = xCoordinate,
                ShipPositionY = yCoordinate,
                BoardId = boardId
            };

            _addShipCommandValidatorTest.ShouldHaveValidationErrorFor(x => x.BoardId, query);
            _addShipCommandValidatorTest.ShouldHaveValidationErrorFor(x => x.ShipPositionX, query);
            _addShipCommandValidatorTest.ShouldHaveValidationErrorFor(x => x.ShipPositionY, query);
        }
    }
}
