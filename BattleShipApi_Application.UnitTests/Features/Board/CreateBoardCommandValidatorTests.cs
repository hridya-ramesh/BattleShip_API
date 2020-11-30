using BattleShip_Application.Feature;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleShipApi_Application.UnitTests.Features.Board
{
   public  class CreateBoardCommandValidatorTests
    {
        private readonly CreateBoardCommanddValidator _createBoardCommandValidatorTests = new CreateBoardCommanddValidator();
        [Theory]
        [InlineData( 0, 0)]
        [InlineData( null, null)]
        public void CreateBoardCommand_WhenInputIsNullOrZero_ReturnsError( int xCoordinate, int yCoordinate)
        {
            var query = new CreateBoardCommand
            {
                DimensionX = xCoordinate,
                DimensionY = yCoordinate
            };

            _createBoardCommandValidatorTests.ShouldHaveValidationErrorFor(x => x.DimensionX, query);
            _createBoardCommandValidatorTests.ShouldHaveValidationErrorFor(x => x.DimensionY, query);
        }
    }
}
