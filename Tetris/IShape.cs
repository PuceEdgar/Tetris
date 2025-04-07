
namespace Tetris
{
	internal class IShape : IPieceShape
	{
		char[,] Up => new char[,] { { MovingPiecePattern, MovingPiecePattern, MovingPiecePattern, MovingPiecePattern } };
		char[,] Down => new char[,] { { MovingPiecePattern, MovingPiecePattern, MovingPiecePattern, MovingPiecePattern } };
		char[,] Left => new char[,] { { MovingPiecePattern, EmptySpace }, { MovingPiecePattern, EmptySpace }, { MovingPiecePattern, EmptySpace }, { MovingPiecePattern, EmptySpace } };
		char[,] Right => new char[,] { { EmptySpace, MovingPiecePattern }, { EmptySpace, MovingPiecePattern }, { EmptySpace, MovingPiecePattern }, { EmptySpace, MovingPiecePattern } };

		private char[,]? currentShape;
		public char[,] CurrentShape
		{
			get { return Direction switch
			{
				PieceDirection.UP => Up,
				PieceDirection.DOWN => Down,
				PieceDirection.LEFT => Left,
				PieceDirection.RIGHT => Right,
				_ => Up
			}; } 
			
			set => currentShape = value;
		}

		public PieceDirection Direction { get; set; }

		
	}
}
