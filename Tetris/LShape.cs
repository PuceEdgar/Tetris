
namespace Tetris
{
	internal class LShape : IPieceShape
	{
		char[,] Up => new char[,] { { EmptySpace, EmptySpace, MovingPiecePattern }, { MovingPiecePattern, MovingPiecePattern, MovingPiecePattern } };
		char[,] Left => new char[,] { { MovingPiecePattern, EmptySpace }, { MovingPiecePattern, EmptySpace }, { MovingPiecePattern, MovingPiecePattern } };
		char[,] Down => new char[,] { { MovingPiecePattern, MovingPiecePattern, MovingPiecePattern }, { MovingPiecePattern, EmptySpace, EmptySpace } };
		char[,] Right => new char[,] { { MovingPiecePattern, MovingPiecePattern }, { EmptySpace, MovingPiecePattern }, { EmptySpace, MovingPiecePattern } };

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
