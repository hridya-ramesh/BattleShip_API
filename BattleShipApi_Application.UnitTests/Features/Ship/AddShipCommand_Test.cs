using BattleShip_Application.Feature;
using BattleShipApi_Application.UnitTests.Utils;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BattleShipApi_Application.UnitTests.Features.Ship
{
    public class AddShipCommand_Test: CreateTestDb
    {
        [Fact]
        public async Task Handle_AddShipCommand_ReturnsResponse()
        {
            // Arrange
            var command = new AddShipCommand { BoardId = 1, ShipPositionX = 10, ShipPositionY = 10 };
            var handler = new AddShipCommandHandler(_context);

            // Act
            Func<Task> response = async () => await handler.Handle(command, default);

            // Assert
            await response.Should().ThrowAsync<Exception>();
        }

        [Fact]
        public async Task Handle_AddShipCommand_ThrowsException()
        {
            // Arrange
            var command = new AddShipCommand { BoardId = 3, ShipPositionX = 4, ShipPositionY = 4 };
            var handler = new AddShipCommandHandler(_context);

            // Act
            Func<Task> response = async () => await handler.Handle(command, default);

            // Assert
            await response.Should().ThrowAsync<Exception>();
        }
    }
}
