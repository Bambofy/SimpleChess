using SFML.Window;

namespace Chess.Pieces
{
    class Bishop : Piece
    {
        public Bishop(Colours colour, int x, int y, Types type = Types.Bishop)
            : base(type, colour, x, y)
        {
            for (int xc = 1; xc <= 7; xc++)
            {
                // diagonals
                Moves.Add(new Vector2i(xc, xc), 3);
                Moves.Add(new Vector2i(-xc, -xc), 3);
                Moves.Add(new Vector2i(-xc, xc), 3);
                Moves.Add(new Vector2i(xc, -xc), 3);
            }
        }
    }
}
