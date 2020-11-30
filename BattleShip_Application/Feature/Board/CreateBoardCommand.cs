using BattleShip_Application.Interface;
using BattleShip_Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShip_Application.Feature
{
    public class CreateBoardCommand : IRequest<int>
    {
      public  int DimensionX { get; set; }
      public int DimensionY  { get; set; }
    }
    public class CreateBoardCommandHandler : IRequestHandler<CreateBoardCommand, int>
    {
       
        private readonly IBattleShipApiDbContext _dbContext;

        public CreateBoardCommandHandler(IBattleShipApiDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<int> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            var  gameBoard = new Board(request.DimensionX,request.DimensionY);
            _dbContext.Boards.Add(gameBoard);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return gameBoard.BoardId;
        }
    }
}
