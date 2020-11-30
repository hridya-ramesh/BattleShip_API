using BattleShip_Application.Feature;
using BattleShipApi_Application.UnitTests.Utils;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace BattleShipApi_Application.UnitTests.Features.Board
{
    public class CreateBoardCommand_Test: CreateTestDb
    {
        [Theory]
        [InlineData( 10,10)]
        [InlineData(5, 5)]
        public async Task Handle_CreateBoardCommand_CreatesBoard(int x, int y)
        {
            // Arrange
            var command = new CreateBoardCommand { DimensionX=x, DimensionY=y};
            var handler = new CreateBoardCommandHandler(_context);

            // Act
            var response = await handler.Handle(command, default);

            // Assert
            response.Should().BePositive();
        }
    }
}
