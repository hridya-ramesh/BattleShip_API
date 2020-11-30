using BattleShip_Application.Feature.Attack;
using BattleShipApi_Application.UnitTests.Utils;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BattleShipApi_Application.UnitTests.Features.Attack
{
    public class AttackCommand_Test: CreateTestDb
    {
        [Fact]
        public async Task Handle_AttackCommand_ReturnsResponse()
        {
            // Arrange
            var command = new AttackCommand {  BoardId =2, AttackPositionX = 1, AttackPositionY = 4 };
            var handler = new AttackCommandHandler(_context);

            // Act
            var response = await handler.Handle(command, default);

            // Assert
            response.AttackStatus.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Handle_AttackCommand_ThrowsException()
        {
            // Arrange
            var command = new AttackCommand { BoardId = 3, AttackPositionX = 10, AttackPositionY = 10 };
            var handler = new AttackCommandHandler(_context);

            // Act
            Func<Task> response = async () => await handler.Handle(command, default);

            // Assert
            await response.Should().ThrowAsync<Exception>();
        }
    }
}
