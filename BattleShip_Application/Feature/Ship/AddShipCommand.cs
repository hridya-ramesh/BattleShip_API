
using BattleShip_Application.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShip_Application.Feature
{
    public class AddShipCommand : IRequest<AddShipCommandResponse>
    {
        public int BoardId { get; set; }
        public int ShipPositionY { get; set; }
        public int ShipPositionX { get; set; }
    }
    public class AddShipCommandHandler : IRequestHandler<AddShipCommand, AddShipCommandResponse>
    {
        private readonly IBattleShipApiDbContext _dbContext;
        public AddShipCommandHandler(IBattleShipApiDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<AddShipCommandResponse> Handle(AddShipCommand request, CancellationToken cancellationToken)
        {
            var board = await _dbContext.Boards.FindAsync(request.BoardId);
            if(board==null)
            {
                throw new Exception("Game is not on");
            }

            var square = board.GameBoard.Find(X => X.Position.XCoordinate == request.ShipPositionX && X.Position.YCoordinate == request.ShipPositionY);
            if(square.Status == BattleShip_Domain.Square.OccupationStatus.Battleship)
            {
                return new AddShipCommandResponse { ShipAdded = false, StatusMessage = "BattleShip exists in this location" };
            }

            square.Status = BattleShip_Domain.Square.OccupationStatus.Battleship;
            _dbContext.Boards.Attach(board).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await  _dbContext.SaveChangesAsync(cancellationToken);
            return new AddShipCommandResponse { ShipAdded = true, StatusMessage = "BattleShip added succesfully" };
        }
    }
}
