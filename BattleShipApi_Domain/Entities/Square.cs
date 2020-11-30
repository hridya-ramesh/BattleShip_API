
namespace BattleShip_Domain
{
    public class Square
    {
        public int Id { get; set; }
        public OccupationStatus Status { get; set; } 
        public Position Position { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        
        public Square(int row, int column)
        {
            Status = OccupationStatus.Empty;
            Position = new Position(row, column);
        }

        public enum OccupationStatus
        {
            Empty,
            Battleship
        }
    }
}
