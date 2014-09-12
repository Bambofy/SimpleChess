using System;
using SFML.Window;
using SFML.Graphics;

namespace Chess
{
    class Chess
    {
        private RenderWindow _window;
        private Pieces.Piece[,] _board;

        public int WhiteNumberOfPieces = 16;
        public int BlackNumberOfPieces = 16;

        /// <summary>
        /// True if second click, false otherwise.
        /// </summary>
        public bool SecondClick = false;

        private Colours _turnColour = Colours.White;
        private Pieces.Piece _selectedPiece;

        public void Start()
        {
            AssetManager.LoadSprites();

            _board = new Pieces.Piece[8, 8];
            for (int x = 0; x < 8; x++ )
            {
                for (int y = 0; y < 8; y++)
                {
                    _board[x, y] = null;
                }
            }


            // Create window instance.
            _window = new RenderWindow(new VideoMode(520, 520), "Chess", Styles.Default);
            _window.SetVisible(true);
            _window.Closed += OnClosed;
            _window.MouseButtonPressed += OnMousePressed;
            LoadTable();
            UpdateTitle();

            // Main loop.
            while (_window.IsOpen())
            {
                _window.DispatchEvents();
                _window.Clear(Color.Black);

                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        RectangleShape shape = new RectangleShape();
                        shape.Size = new Vector2f(65, 65);
                        shape.Position = new Vector2f(x*65, y*65);

                        Color col = ((x+y)%2) == 0 ? new Color(255, 206, 158) : new Color(209, 139, 71);

                        shape.FillColor = col;
                        _window.Draw(shape);
                    }
                }

                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        var piece = _board[x, y];
                        if (piece != null)
                        {
                            _window.Draw(piece.Sprite);
                        }
                    }
                }


                if (SecondClick)
                {
                    RectangleShape shape = new RectangleShape();
                    shape.Size = new Vector2f(65, 65);
                    shape.Position = _selectedPiece.Sprite.Position;

                    Color col = Color.Cyan;

                    shape.OutlineColor = col;
                    shape.OutlineThickness = 4;
                    shape.FillColor = new Color(255, 255, 255, 0);
                    _window.Draw(shape);
                }

                _window.Display();
            }
        }

        void UpdateTitle()
        {
            _window.SetTitle("Chess  W:" + WhiteNumberOfPieces + "  B:" + BlackNumberOfPieces + " - " + _turnColour.ToString() + "'s move");
        }

        void LoadTable()
        {
            for (int x = 0; x <= 7; x++)
            {
                _board[x, 1] = new Pieces.Pawn(Colours.Black, x, 1);
                _board[x, 6] = new Pieces.Pawn(Colours.White, x, 6);
            }
            _board[0, 0] = new Pieces.Rook(Colours.Black, 0, 0);
            _board[1, 0] = new Pieces.Knight(Colours.Black, 1, 0);
            _board[2, 0] = new Pieces.Bishop(Colours.Black, 2, 0);
            _board[3, 0] = new Pieces.Queen(Colours.Black, 3, 0);
            _board[4, 0] = new Pieces.King(Colours.Black, 4, 0);
            _board[5, 0] = new Pieces.Bishop(Colours.Black, 5, 0);
            _board[6, 0] = new Pieces.Knight(Colours.Black, 6, 0);
            _board[7, 0] = new Pieces.Rook(Colours.Black, 7, 0);

            _board[0, 7] = new Pieces.Rook(Colours.White, 0, 7);
            _board[1, 7] = new Pieces.Knight(Colours.White, 1, 7);
            _board[2, 7] = new Pieces.Bishop(Colours.White, 2, 7);
            _board[3, 7] = new Pieces.Queen(Colours.White, 3, 7);
            _board[4, 7] = new Pieces.King(Colours.White, 4, 7);
            _board[5, 7] = new Pieces.Bishop(Colours.White, 5, 7);
            _board[6, 7] = new Pieces.Knight(Colours.White, 6, 7);
            _board[7, 7] = new Pieces.Rook(Colours.White, 7, 7);
        }

        // Check for closures.
        void OnClosed(object sender, EventArgs e)
        {
            _window.Close();
        }

        void OnMousePressed(object sender, MouseButtonEventArgs e)
        {
            // Get piece at coordinates.
            var place = _board[e.X / 65, e.Y / 65];

            // Either move or take piece.
            if (SecondClick)
            {
                // toggle off
                if (place == _selectedPiece)
                {
                    SecondClick = false;
                }

                // If second click is an empty space, try to move piece. will return false is failure.
                var moved = _selectedPiece.MoveTo(ref _board, e.X / 65, e.Y / 65);

                switch (moved)
                {
                    case 3:
                        if (_turnColour == Colours.White)
                        {
                            BlackNumberOfPieces--;
                            UpdateTitle();
                        }
                        else
                        {
                            WhiteNumberOfPieces--;
                            UpdateTitle();
                        }
                        break;
                    case 1:
                        return;
                }
                
                _turnColour = _turnColour == Colours.White ? Colours.Black : Colours.White;
                UpdateTitle();
            }
            else
            {
                // Just piece selection.
                if (place != null)
                {
                    // there is a piece here.
                    if (place.Colour == _turnColour)
                    {
                        // its the turns type of piece.
                        _selectedPiece = place;
                    }
                    else
                    {
                        // do nothing.
                        return;
                    }
                }
                else
                {
                    // do nothing.
                    return;
                }
            }

            SecondClick = !SecondClick;
        }
    }
}
