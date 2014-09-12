using System.Linq;
using SFML.Window;

namespace Chess.Pieces
{
    class Pawn : Piece
    {
        private bool _hasMoved;

        public Pawn(Colours colour, int x, int y, Types type = Types.Pawn) : base (type, colour, x, y)
        {
            if (colour == Colours.Black)
            {
                Moves.Add(new Vector2i(0, 1), 1);
                Moves.Add(new Vector2i(-1, 1), 2);
                Moves.Add(new Vector2i(1, 1), 2);
                Moves.Add(new Vector2i(0, 2), 1);
            }
            else
            {
                Moves.Add(new Vector2i(0, -1), 1);
                Moves.Add(new Vector2i(-1, -1), 2);
                Moves.Add(new Vector2i(1, -1), 2);
                Moves.Add(new Vector2i(0, -2), 1);
            }
        }

        public override int MoveTo(ref Piece[,] board, int x, int y)
        {
            var movementId = base.MoveTo(ref board, x, y);

            _hasMoved = true;
            if (_hasMoved != true) return movementId;

            foreach (var pair in Moves.Where(pair => (pair.Key.Y == 2) || (pair.Key.Y == -2)))
            {
                // remove eet
                Moves.Remove(pair.Key);
                break;
            }
            return movementId;
        }
    }
}
