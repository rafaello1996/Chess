﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class TBishop : TPiece
    {
        public TBishop(TPlayer player) : base(player)
        {
            ImageId = 0;
            Value = 3;
        }

        public override List<TCell> GetFreeCells()
        {
            var cells = new List<TCell>();
            cells.AddRange(GetFreeCellsFromDir(1, 1));
            cells.AddRange(GetFreeCellsFromDir(-1, -1));
            cells.AddRange(GetFreeCellsFromDir(-1, 1));
            cells.AddRange(GetFreeCellsFromDir(1, -1));
            return cells;
        }
    }
}
