namespace Chess
{
    public enum Colours
    {
        Black,
        White,
        Empty
    }

    public enum Types
    {
        Pawn,
        Rook,
        Knight,
        Bishop,
        Queen,
        King,
        Empty
    }

    class Program
    {
        static void Main()
        {
            Chess game = new Chess();
            game.Start();
        }
    }
}
