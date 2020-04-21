﻿using System.Collections.Generic;

namespace Chess
{
    public abstract class TPiece
    {
        public int ImageId;
        public int Value;
        public TPlayer Player;
        public TCell Cell;
        public TPiece(TPlayer player)
        {
            Player = player;
            Player.Pieces.Add(this);
        }

        public int MoveCount;
        public abstract List<TCell> GetFreeCells();
        public List<TMove> GetMoves()
        {
            var cells = GetFreeCells();
            var moves = new List<TMove>();
            foreach( var cell in cells)
            {
                if (cell == null)
                    continue;
                var capture = cell.Piece;
                if (capture?.Player == Player)
                    continue;
                var move = new TMove();
                move.Piece = this;
                move.StartCell = Cell;
                move.StopCell = cell;
                move.Capture = capture;
                moves.Add(move);
            }
            return moves;
        }

        public List<TCell> GetFreeCellsFromDir(int offX, int offY)
        {
            var cells = new List<TCell>();
            var cell = Cell;
            do
            {
                cell = cell.GetNeighbor(offX, offY);
                cells.Add(cell);
            }
            while (cell != null && cell.Piece != null);
            return cells;
        }
    }
}