
namespace Tetris
{
	internal interface IPieceShape
	{
		public char[,] Up { get; }
		public char[,] Left { get; }
		public char[,] Down { get; }
		public char[,] Right { get; } 
	}
}
