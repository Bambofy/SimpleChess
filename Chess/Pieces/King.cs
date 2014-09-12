using SFML.Window;

namespace Chess.Pieces
{
    class King : Piece
    {
        public King(Colours colour, int x, int y, Types type = Types.King)
            : base(type, colour, x, y)
        {
            Moves.Add(new Vector2i(-1, -1), 3);
            Moves.Add(new Vector2i(-1, 0), 3);
            Moves.Add(new Vector2i(-1, 1), 3);
            Moves.Add(new Vector2i(0, -1), 3);
            Moves.Add(new Vector2i(0, 0), 3);
            Moves.Add(new Vector2i(0, 1), 3);
            Moves.Add(new Vector2i(1, -1), 3);
            Moves.Add(new Vector2i(1, 0), 3);
            Moves.Add(new Vector2i(1, 1), 3);
        }
    }
}
