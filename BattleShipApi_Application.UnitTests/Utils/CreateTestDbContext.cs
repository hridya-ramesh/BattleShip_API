using BattleShip_Domain;
using BattleShipApi_Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace BattleShipApi_Application.UnitTests.Utils
{
   public class CreateTestDb:IDisposable
    {
        protected readonly BattleShipApiDbContext _context;

        public CreateTestDb()
        {
            _context = CreateContext();
        }

        public static BattleShipApiDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<BattleShipApiDbContext>()
                .UseInMemoryDatabase("test-DB")
                .Options;

            var context = new BattleShipApiDbContext(options);
            var board = new Board(10, 10);
            context.Boards.Add(board);
            context.Boards.Add(new Board(5, 5));
            //context.Squares.Add(new Square(10, 1));
            //context.Positions.Add(new Position(10, 1));

            context.Database.EnsureCreated();
            return context;

        }

        public void Dispose()
        {
             _context.Database.EnsureDeleted();

            _context.Dispose();
        }
    }
}
