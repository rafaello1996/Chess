using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class TPawn : TPiece
    {
        public TPawn(TPlayer player) : base(player)
        {
            ImageId = 6;
            Value = 1;
        }

        public override List<TCell> GetFreeCells()
        {
            var cells = new List<TCell>();
            var dir = Player == Player.Board.WhitePlayer ? 1 : -1;
            var cell = Cell.GetNeighbor(1,dir);
            if (cell.Piece != null)
                cells.Add(cell);
            cell = Cell.GetNeighbor(-1, dir);
            if (cell.Piece != null)
                cells.Add(cell);
            cell = Cell.GetNeighbor(0, dir);
            if (cell.Piece == null)
            {
                cells.Add(cell);
                if (MoveCount == 0)
                {
                    cell = cell.GetNeighbor(0, dir);
                    if (cell.Piece == null)
                        cells.Add(cell);
                }

            }              

            return cells;
        }
    }
}
