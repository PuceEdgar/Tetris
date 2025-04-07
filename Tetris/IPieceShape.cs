
namespace Tetris
{
	internal interface IPieceShape
	{
		public char[,] CurrentShape { get; }
		public PieceDirection Direction { get; set; }
	}
}
