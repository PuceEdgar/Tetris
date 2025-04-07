
namespace Tetris
{
	internal class TShape : IPieceShape
	{
		char[,] Up => new char[,] { { EmptySpace, MovingPiecePattern, EmptySpace }, { MovingPiecePattern, MovingPiecePattern, MovingPiecePattern } };
		char[,] Left => new char[,] { { MovingPiecePattern, EmptySpace }, { MovingPiecePattern, MovingPiecePattern }, { MovingPiecePattern, EmptySpace } };
		char[,] Down => new char[,] { { MovingPiecePattern, MovingPiecePattern, MovingPiecePattern }, { EmptySpace, MovingPiecePattern, EmptySpace } };
		char[,] Right => new char[,] { { EmptySpace, MovingPiecePattern }, { MovingPiecePattern, MovingPiecePattern }, { EmptySpace, MovingPiecePattern } };

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
