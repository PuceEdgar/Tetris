
namespace Tetris
{
	internal class ZShape : IPieceShape
	{
		char[,] Up => new char[,] { { MovingPiecePattern, MovingPiecePattern, EmptySpace }, { EmptySpace, MovingPiecePattern, MovingPiecePattern } };
		char[,] Left => new char[,] { { EmptySpace, MovingPiecePattern }, { MovingPiecePattern, MovingPiecePattern }, { MovingPiecePattern, EmptySpace } };
		char[,] Down => new char[,] { { MovingPiecePattern, MovingPiecePattern, EmptySpace }, { EmptySpace, MovingPiecePattern, MovingPiecePattern } };
		char[,] Right => new char[,] { { EmptySpace, MovingPiecePattern }, { MovingPiecePattern, MovingPiecePattern }, { MovingPiecePattern, EmptySpace } };

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
