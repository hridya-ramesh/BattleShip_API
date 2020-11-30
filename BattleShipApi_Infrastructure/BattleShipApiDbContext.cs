using BattleShip_Application.Interface;
using BattleShip_Domain;
using Microsoft.EntityFrameworkCore;

namespace BattleShipApi_Infrastructure
{
    public class BattleShipApiDbContext : DbContext, IBattleShipApiDbContext

    {
        public BattleShipApiDbContext(DbContextOptions<BattleShipApiDbContext> options)
           : base(options)
        {
        }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Square> Squares { get; set; }
        public DbSet<Position> Positions { get; set; }

    }
}
