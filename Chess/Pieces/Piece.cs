using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;

namespace Chess.Pieces
{

    class Piece
    {
        /// <summary>
        /// Board coordinates.
        /// </summary>
        public Vector2i Position;

        /// <summary>
        /// What type of piece it is, eg. Types.Rook.
        /// </summary>
        public Types Type;

        /// <summary>
        /// Colours.Black or Colours.White?
        /// </summary>
        public Colours Colour;

        /// <summary>
        /// What image to draw to screen.
        /// </summary>
        public Sprite Sprite;

        /// <summary>
        /// Where can this piece go?
        /// </summary>
        public Dictionary<Vector2i, int> Moves;

        /// <summary>
        /// Is this selected or not?
        /// </summary>
        public bool Selected;

        public Piece(Types type, Colours colour, int x, int y)
        {
            Selected = false;

            // Assign info.
            Position = new Vector2i(x, y);
            Type = type;
            Colour = colour;

            // Load sprite
            Sprite = new Sprite(AssetManager.GetSprite(type, colour));
            Sprite.Position = new Vector2f(Position.X * 65, Position.Y * 65);

            // Movement info.
            Moves = new Dictionary<Vector2i, int>();
        }

        private void UpdatePos(ref Piece[,] board, int x, int y)
        {
            board[Position.X, Position.Y] = null;

            Sprite.Position = new Vector2f(x* 65, y * 65);
            Position = new Vector2i(x, y);
        }


        /// <summary>
        /// Returns an integer telling what has occured.
        /// 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>1 = Cannot Move, 2 = Moved, 3 = Taken a piece and moved.</returns>
        virtual public int MoveTo(ref Piece[,] board, int x, int y)
        {
            if ((x < 0) || (x > 7)) return 1;
            if ((y < 0) || (y > 7)) return 1;

            foreach (var move in Moves)
            {
                Vector2i newPosition;

                newPosition.X = Position.X + move.Key.X;
                newPosition.Y = Position.Y + move.Key.Y;

                if (newPosition.X != x) continue;
                if (newPosition.Y != y) continue;

                // we know he's trying to do a legal move.
                var entryAtNewPos = board[newPosition.X, newPosition.Y];

                if (entryAtNewPos == null)
                {
                    // nobody there can we move there?
                    switch (move.Value)
                    {
                        case 3:
                        case 1:
                            board[newPosition.X, newPosition.Y] = this;
                            UpdatePos(ref board, newPosition.X, newPosition.Y);
                            return 2;
                        case 2:
                            return 1;
                    }
                }
                else if (entryAtNewPos.Colour != Colour)
                {
                    // there's somewhere there, can we take it tho?
                    switch (move.Value)
                    {
                        case 1:
                            return 1;
                        case 3:
                        case 2:
                            board[newPosition.X, newPosition.Y] = this;
                            UpdatePos(ref board, newPosition.X, newPosition.Y);
                            return 3;
                    }
                }
                else if (entryAtNewPos.Colour == Colour)
                {
                    return 1;
                }
            }

            return 1;
        }


    }
}
