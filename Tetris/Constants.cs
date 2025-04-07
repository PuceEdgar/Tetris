
namespace Tetris
{
	internal static class Constants
	{
		public static char MovingPiecePattern = 'O';
		public static char LandedPiecePattern = 'X';
		public static char Border = '*';
		public static char EmptySpace = ' ';

		public static IPieceShape GetShape(int number)
		{
			return number switch 
			{
				1 => new IShape(),
				2 => new JShape(),
				3 => new LShape(),
				4 => new OShape(),
				5 => new SShape(),
				6 => new TShape(),
				8 => new ZShape(),
				_ => new OShape()
			};
		}
	}
}
