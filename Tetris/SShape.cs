namespace Tetris
{
	internal class SShape : IPieceShape
	{
		public char[,] Up => new char[,] { { ' ', 'X', 'X' }, { 'X', 'X', ' ' } };

		public char[,] Left => new char[,] { { 'X', ' ' }, { 'X', 'X' }, { ' ', 'X' } };

		public char[,] Down => new char[,] { { ' ', 'X', 'X' }, { 'X', 'X', ' ' } };

		public char[,] Right => new char[,] { { 'X', ' ' }, { 'X', 'X' }, { ' ', 'X' } };
	}
}
