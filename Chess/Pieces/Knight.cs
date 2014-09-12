using SFML.Window;

namespace Chess.Pieces
{
    class Knight : Piece
    {
        public Knight(Colours colour, int x, int y, Types type = Types.Knight)
            : base(type, colour, x, y)
        {
            Moves.Add(new Vector2i(-2, -1), 3);
            Moves.Add(new Vector2i(-1, -2), 3);

            Moves.Add(new Vector2i(2, -1), 3);
            Moves.Add(new Vector2i(1, -2), 3);

            Moves.Add(new Vector2i(2, 1), 3);
            Moves.Add(new Vector2i(1, 2), 3);

            Moves.Add(new Vector2i(-2, 1), 3);
            Moves.Add(new Vector2i(-1, 2), 3);
        }
    }
}
