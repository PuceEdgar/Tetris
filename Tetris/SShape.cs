namespace Tetris
{
	internal class SShape : IPieceShape
	{
		char[,] Up => new char[,] { { EmptySpace, MovingPiecePattern, MovingPiecePattern }, { MovingPiecePattern, MovingPiecePattern, EmptySpace } };
		char[,] Left => new char[,] { { MovingPiecePattern, EmptySpace }, { MovingPiecePattern, MovingPiecePattern }, { EmptySpace, MovingPiecePattern } };
		char[,] Down => new char[,] { { EmptySpace, MovingPiecePattern, MovingPiecePattern }, { MovingPiecePattern, MovingPiecePattern, EmptySpace } };
		char[,] Right => new char[,] { { MovingPiecePattern, EmptySpace }, { MovingPiecePattern, MovingPiecePattern }, { EmptySpace, MovingPiecePattern } };

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
