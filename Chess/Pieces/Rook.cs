using SFML.Window;

namespace Chess.Pieces
{
    class Rook : Piece
    {
        public Rook(Colours colour, int x, int y, Types type = Types.Rook)
            : base(type, colour, x, y)
        {
            for (int xc = 1; xc <= 7; xc++)
            {
                // horizontals
                Moves.Add(new Vector2i(xc, 0), 3);
                Moves.Add(new Vector2i(-xc, 0), 3);
                Moves.Add(new Vector2i(0, xc), 3);
                Moves.Add(new Vector2i(0, -xc), 3);
            }
        }
    }
}
