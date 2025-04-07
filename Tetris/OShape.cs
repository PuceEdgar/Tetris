
namespace Tetris
{
	internal class OShape : IPieceShape
	{
		char[,] Up => new char[,] { { MovingPiecePattern, MovingPiecePattern }, { MovingPiecePattern, MovingPiecePattern } };
		char[,] Left => new char[,] { { MovingPiecePattern, MovingPiecePattern }, { MovingPiecePattern, MovingPiecePattern } };
		char[,] Down => new char[,] { { MovingPiecePattern, MovingPiecePattern }, { MovingPiecePattern, MovingPiecePattern } };
		char[,] Right => new char[,] { { MovingPiecePattern, MovingPiecePattern }, { MovingPiecePattern, MovingPiecePattern } };

		char[,]? currentShape;
		public char[,] CurrentShape
		{
			get
			{
				return Direction switch
				{
					PieceDirection.UP => Up,
					PieceDirection.DOWN => Down,
					PieceDirection.LEFT => Left,
					PieceDirection.RIGHT => Right,
					_ => Up
				};
			}

			set => currentShape = value;
		}

		public PieceDirection Direction { get; set; }
	}
}
