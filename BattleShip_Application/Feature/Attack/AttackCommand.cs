
using BattleShip_Application.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShip_Application.Feature.Attack
{
    public class AttackCommand : IRequest<AttackResponse>
    {
        public int BoardId { get; set; }
        public int AttackPositionY { get; set; }
        public int AttackPositionX { get; set; }
    }

    public class AttackCommandHandler : IRequestHandler<AttackCommand, AttackResponse>
    {
        private readonly IBattleShipApiDbContext _dbContext;
        public AttackCommandHandler(IBattleShipApiDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<AttackResponse> Handle(AttackCommand request, CancellationToken cancellationToken)
        {
            var board = await _dbContext.Boards.FindAsync(request.BoardId);
            if (board == null)
            {
                throw new Exception("Game is not on");
            }

            var square = board.GameBoard.Find(X => X.Position.XCoordinate == request.AttackPositionX && X.Position.YCoordinate == request.AttackPositionY);

            if (square != null)
            {
                return new AttackResponse { AttackStatus = "Hit" };
            }
            else
            {
                return new AttackResponse { AttackStatus = "Miss" };
            }
        }
    }
}
