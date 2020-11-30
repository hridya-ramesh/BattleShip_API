using BattleShip_Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShip_Application.Interface
{
   public interface IBattleShipApiDbContext
    {
        DbSet<Board> Boards { get; set; }
        DbSet<Square> Squares { get; set; }
        DbSet<Position> Positions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
