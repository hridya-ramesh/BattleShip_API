using System.Collections.Generic;

namespace BattleShip_Domain
{
    public class Board
    {
        public  virtual List<Square> GameBoard { get; set; }
        public int BoardId { get; set; }
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public Board(int dimensionX, int dimensionY)
        {
            GameBoard = new List<Square>();
            DimensionX = dimensionX;
            DimensionY = dimensionY;
            for (int i = 1; i <= dimensionX; i++)
            {
                for (int j = 1; j <= dimensionY; j++)
                {
                    GameBoard.Add(new Square(i, j));
                }
            }
        }
    }
}
