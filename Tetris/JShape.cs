
namespace Tetris
{
	internal class JShape : IPieceShape
	{
		char[,] Up => new char[,] { { MovingPiecePattern, EmptySpace, EmptySpace }, { MovingPiecePattern, MovingPiecePattern, MovingPiecePattern } };

		char[,] Left => new char[,] { { MovingPiecePattern, MovingPiecePattern }, { MovingPiecePattern, EmptySpace }, { MovingPiecePattern, EmptySpace } };

		char[,] Down => new char[,] { { MovingPiecePattern, MovingPiecePattern, MovingPiecePattern }, { EmptySpace, EmptySpace, MovingPiecePattern } };

		char[,] Right => new char[,] { { EmptySpace, MovingPiecePattern }, { EmptySpace, MovingPiecePattern }, { MovingPiecePattern, MovingPiecePattern } };

		private char[,]? currentShape;
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
